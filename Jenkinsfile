pipeline {
    agent {
        docker {
            image 'node:14-alpine'
        }
    }
    stages {
        stage('Pre') {
            steps {
                echo 'Hello world - Pre...'
            }
        }
        stage('Build') {
            steps {
                echo 'Hello world - Building...'
            }
        }
    }
}