pipeline {
    agent {
        dockerfile true
    }
    stages {
        stage('Pre') {
            steps {
                echo '- Step 0: Preparation'
                echo '$WORKSPACE/'
                sh 'ls $WORKSPACE/'
                sh 'dotnet --version'
            }
        }
        stage('Build') {
            steps {
                echo 'Hello world - Building...'
            }
        }
    }
}