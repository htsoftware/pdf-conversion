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
        stage('Restore') {
            steps {
                // sh 'dotnet restore $WORKSPACE/PdfConversion/PdfConversion.csproj'
                sh 'ls /app/build'   
            }
        }
        stage('Build') {
            steps {
                echo 'Hello world - Building...'
            }
        }
    }
}