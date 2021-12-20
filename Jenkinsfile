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
                sh 'dotnet restore Backend-NET.sln'
                discordSend description: ":adhesive_bandage: Restored Packages for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }

        stage('Clean Workspace') {
            steps {
                sh 'dotnet clean Backend-NET.sln --configuration Release'
                discordSend description: ":soap: Cleaned Workspace for ${env.JOB_NAME}", result: currentBuild.currentResult, webhookURL: env.WEBHO_NET
            }
        }
    }
}