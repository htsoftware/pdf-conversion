pipeline {
    agent {
        dockerfile true
    }
    stages {
        stage('Pre') {
            steps {
                echo 'Hello world - Pre...'
                echo '$WORKSPACE/'
                sh 'ls $WORKSPACE/'
            }
        }
        stage('Build') {
            steps {
                echo 'Hello world - Building...'
            }
        }
    }
}