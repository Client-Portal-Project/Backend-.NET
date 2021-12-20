pipeline {
    agent any
    options {
        buildDiscarder(logRotator(daysToKeepStr: '90', numToKeepStr: '1'))
        disableConcurrentBuilds()
    }

    tools{ msbuild 'msbuild'}

    stages {
        stage('Restore Package') {
            steps {
                sh 'dotnet restore Backend-NET.sln'
            }
        }
    }
}