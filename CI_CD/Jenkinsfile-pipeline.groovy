pipeline {
    agent any
    triggers {
        pollSCM('* * * * *')
    }
    stages {
        stage('Audit tools') {
            steps {
                sh '''
                    git version
                    '''
                }
        }
        stage('Clone sources') {
            steps {
                git 'https://github.com/G0m0r0/GreenCap-Web-Project.git'
            }
        }
        stage('Build') {
            steps {
                sh './mvnw compile'
                sh './mvnw install'
                sh './mvnw package'
            }
        }
        stage('SonarQube analysis') {
            steps {
                withSonarQubeEnv(installationName: 'SonarServer') {
                    sh './mvnw sonar:sonar -Dsonar.host.url=http://sonarqube:9081'
                }
            }
        }
        stage('Quality gate') {
            steps {
                timeout(time: 2, unit: 'MINUTES') {
                waitForQualityGate abortPipeline: true
               }
            }
        }
    }
    post {
        always {
            echo 'always'
        }
        success {
            archiveArtifacts artifacts: 'target/*.jar', followSymlinks: false, onlyIfSuccessful: true
        }
        failure {
            emailext body: 'Your test has failed!',
            recipientProviders: [buildUser()], subject: 'Failed test', to: ''
            echo 'Failed!'
        }
    }
}

/* groovylint-disable-next-line ImplicitReturnStatement */
/*String auditTools() {
    sh '''
        git version
        java -version
    '''
//     docker -v
//     brew -v
//     mvn -version
}*/
