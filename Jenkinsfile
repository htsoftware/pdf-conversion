node {
    try {
        stage('Pre') {
            echo '$WORKSPACE'
            echo 'Checkout branch ' + env.BRANCH_NAME
            sh 'ls $WORKSPACE'
        }
        stage('StagingBuild') {
            def customImage = docker.build("my-image:${env.BUILD_ID}")
            customImage.inside {
                sh 'cp -r /app/build/ $WORKSPACE'
                sh 'ls -lh $WORKSPACE'
            }
        }
        stage('StagingDeploy') {
            if (env.BRANCH_NAME == 'develop') {
                withCredentials([string(credentialsId: '60c0076e-70e9-47ad-9752-bc769dba9c36', variable: 'STAGING_USER_HOST'),]) {
                    sshagent(credentials: ['01720db2-a084-4baa-b256-665aa949424c']) {
                        sh 'ssh -o UserKnownHostsFile=/dev/null -o StrictHostKeyChecking=no $STAGING_USER_HOST \'chown dmdtfs /opt/dmdt-fs/pdf-conversion\''
                        sh 'ssh -o UserKnownHostsFile=/dev/null -o StrictHostKeyChecking=no $STAGING_USER_HOST \'rm -rf /opt/dmdt-fs/pdf-conversion/*\''
                        sh 'scp -o UserKnownHostsFile=/dev/null -o StrictHostKeyChecking=no -r build/* $STAGING_USER_HOST:/opt/dmdt-fs/pdf-conversion/'
                        sh 'ssh -o UserKnownHostsFile=/dev/null -o StrictHostKeyChecking=no $STAGING_USER_HOST \'systemctl restart pdf-conversion-service\''
                    }
                }
            }
        }
    }
    catch(exc) {
        echo 'Failed'
        throw exc
    }
    finally {
        stage('Cleanup') {
            cleanWs()
        }
    }
}