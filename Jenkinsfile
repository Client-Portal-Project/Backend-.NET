pipeline {
    agent any
    options {
        buildDiscarder(logRotator(daysToKeepStr: '90', numToKeepStr: '1'))
        disableConcurrentBuilds()
    }

    stages {
        stage('Restore Package') {
            steps {
                sh 'printenv'
                sh 'dotnet -h'
            }
        }
    }
}