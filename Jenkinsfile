def curr = 'pre-pipeline'
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
                script { curr = 'Restoring' }
                sh 'dotnet restore Backend-NET.sln'
                discordSend description: ":adhesive_bandage: Restored Packages for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Clean Workspace') {
            steps {
                script { curr = 'Cleaning' }
                sh 'dotnet clean Backend-NET.sln --configuration Release'
                discordSend description: ":soap: Cleaned Workspace for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Build') {
            steps {
                script { curr = 'Building' }
                sh 'dotnet build Backend-NET.sln --configuration Release --no-restore'
                discordSend description: ":tools: Built Files for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: WEBHO_NET
            }
        }
    }
    post {
        failure {
            discordSend title: "**:boom: ${env.JOB_NAME} Pipeline Failure**"
                        description: "Failed in the ${curr} Stage", 
                        footer: "@Backend - .Net",
                        result: currentBuild.currentResult, webhookURL: WEBHO_NET
        }
    }
}