def CURR = 'Pre-Pipeline'
def CMD = 'No command given'
def ERR = 'NONE'

pipeline {
    agent any
    options {
        buildDiscarder(logRotator(daysToKeepStr: '90', numToKeepStr: '1'))
        disableConcurrentBuilds()
    }

    tools {dotnetsdk 'dotnet'}

    environment {
        DOCKERHUB_CREDENTIALS = credentials('clientportalx-dockerhub')
    }

    stages {
        stage('Restore Package') {
            steps {
                script { 
                    CURR = 'Restoring' 
                    CMD = 'dotnet restore Backend-NET.sln > result'
                    if (sh(script: CMD, returnStatus: true) != 0) {
                        ERR = readFile('result').trim()
                        CMD = CMD.split(" > ")[0].trim()
                        error('Failed')
                    }
                }
                discordSend description: ":adhesive_bandage: Restored Packages for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Clean Workspace') {
            steps {
                script { 
                    CURR = 'Cleaning'
                    CMD = 'dotnet clean Backend-NET.sln --configuration Release > result'
                    if (sh(script: CMD, returnStatus: true) != 0) {
                        ERR = readFile('result').trim()
                        CMD = CMD.split(" > ")[0].trim()
                        error('Failed')
                    }
                }
                discordSend description: ":soap: Cleaned Workspace for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Build') {
            environment {
                ORG = "client-portal-project"
                NAME = "Backend-.NET"
            }
            steps {
                script {
                    CURR = 'Building'
                    CMD = "dotnet build Backend-NET.sln --configuration Release --no-restore > result"
                    if (sh(script: CMD, returnStatus: true) != 0) {
                        ERR = readFile('result').trim()
                        CMD = CMD.split(" > ")[0].trim()
                        error('Failed')
                    }
                }
                discordSend description: ":tools: Built Files for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: WEBHO_NET
            }
        }

        stage('Static Analysis') {
            environment {
                SCAN = tool 'dotnet-scanner'
                ORG = "client-portal-project"
                NAME = "Backend-.NET"
            }
            steps {
                script {
                    CURR = 'Static Analysis'
                    CMD = '''$SCAN/SonarScanner.MSBuild.dll begin /k:$NAME /o:$ORG \
                            dotnet build Backend-NET.sln \
                            $SCAN/SonarScanner.MSBuild.dll end '''
                }
                withSonarQubeEnv('sonarserve') {
                    sh(script: CMD)
                }
                timeout(time: 5, unit: 'MINUTES') {
                    script{
                        ERR = waitForQualityGate()
                        if (ERR.status != 'OK') {
                            writeFile(file: 'result', text: "${ERR}")
                            error('Quality Gate Failed')
                        }
                    }
                }
                discordSend description: ":unlock: Passed Static Analysis of ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Docker Image Build'){
            steps {
                script {
                    CURR = "Docker Image"
                    CMD = "docker build -t clientportalx/dotnet-backend:latest . > result"
                }
                sh (script: CMD)
                discordSend description: ":whale2: Built Docker Image for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_DOCK
            }
        }

        stage("Login to Docker Hub"){
            steps {
                sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
                discordSend description: ":key: Successfully logged into Dockerhub for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_DOCK
            }
        }

        stage('Push to Docker Hub'){
            steps {
                sh 'docker image push clientportalx/angular-frontend:latest'
                discordSend description: ":whale: Pushed Docker Image to Dockerhub for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_DOCK
            }
        }
    }
    post {
        always {
            sh 'cat result'
        }
        failure {
            discordSend title: "**:boom: ${env.JOB_NAME} Failure in ${CURR} Stage**",
                        description: "*${CMD}*\n\n${ERR}",
                        footer: "Follow title URL for full console output",
                        link: env.BUILD_URL + "console", image: 'https://jenkins.io/images/logos/fire/256.png',
                        result: currentBuild.currentResult, webhookURL: WEBHO_NET
        }
    }
}
