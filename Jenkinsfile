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
                echo '- Step 1: Build'
                sh 'ls /app/build -p'
                sh 'cp -r /app/build/ $WORKSPACE/'
                sh 'ls -lh $WORKSPACE/'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Hello world - Building...'
            }
        }
    }
}