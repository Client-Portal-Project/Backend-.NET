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

    stages {
        stage('Restore Package') {
            steps {
                script { 
                    CURR = 'Restoring' 
                    CMD = 'dotnet restore Backend-NET.sln > err'
                    ERR = sh(script: CMD, returnStdout: true)
                }
                discordSend description: ":adhesive_bandage: Restored Packages for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Clean Workspace') {
            steps {
                script { 
                    CURR = 'Cleaning'
                    CMD = 'dotnet clean Backend-NET.sln --configuration Release 2> err'
                    sh "${CMD}"
                    ERR = readFile('err').trim()
                }
                discordSend description: ":soap: Cleaned Workspace for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Build') {
            steps {
                script {
                    CURR = 'Building'
                    CMD = 'dotnet build Backend-NET.sln --configuration Release --no-restore > err'
                    if (sh(script: CMD, returnStatus: true) != 0) ERR = readFile('err').trim()
                }
                discordSend description: ":tools: Built Files for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: WEBHO_NET
            }
        }
    }
    post {
        always {
            echo "${ERR}"
        }
        failure {
            discordSend title: "**:boom: ${env.JOB_NAME} Failure in ${CURR} Stage**",
                        description: "*${CMD}*\n\n${ERR}",
                        result: currentBuild.currentResult, webhookURL: WEBHO_NET
        }
    }
}