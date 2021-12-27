pipeline {
    agent any
    options {
        buildDiscarder(logRotator(daysToKeepStr: '90', numToKeepStr: '1'))
        disableConcurrentBuilds()
    }

    tools {dotnetsdk 'dotnet'}

    environment {
        CURR = 'Pre-Pipeline'
        CMD = 'No command given'
        ERR = 'NONE'
    }

    stages {
        stage('Restore Package') {
            steps {
                script { 
                    env.CURR = 'Restoring' 
                    env.CMD = 'dotnet restore Backend-NET.sln'
                    env.ERR = sh (script: CMD)
                }
                discordSend description: ":adhesive_bandage: Restored Packages for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Clean Workspace') {
            steps {
                script { 
                    env.CURR = 'Cleaning'
                    env.CMD = 'dotnet clean Backend-NET.sln --configuration Release'
                    env.ERR = sh (script: CMD)
                }
                discordSend description: ":soap: Cleaned Workspace for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Build') {
            steps {
                script {
                    env.CURR = 'Building'
                    env.CMD = 'dotnet build Backend-NET.sln --configuration Release --no-restore'
                    env.ERR = sh (script: CMD)
                }
                discordSend description: ":tools: Built Files for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: WEBHO_NET
            }
        }
    }
    post {
        failure {
            discordSend title: "**:boom: ${env.JOB_NAME} Failure in ${curr} Stage**",
                        description: "*${cmd}*\n\n" +
                        "${ERR}",
                        result: currentBuild.currentResult, webhookURL: WEBHO_NET
        }
    }
}