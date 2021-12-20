pipeline {
    agent any
    options {
        buildDiscarder(logRotator(daysToKeepStr: '90', numToKeepStr: '1'))
        disableConcurrentBuilds()
    }

    tools {dotnet 'dotnet'}

    stages {
        stage('Restore Package') {
            steps {
                sh 'printenv'
                sh 'dotnet -h'
            }
        }
    }
}