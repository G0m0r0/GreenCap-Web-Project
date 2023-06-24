pipeline {
    agent any

    triggers {
        pollSCM('H * * * *')
    }

    stages {
        stage('Audit tools') {
            steps {
                sh '''
                    echo "Git:"
                    git --version

                    echo "\n.NET:"
                    dotnet --version
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
                sh 'cd src && dotnet build GreenCap.sln'
            }
        }

        stage('Create Docker image') {
            steps {
                sh 'docker build -t your-dockerhub-username/your-repo-name:latest CI_CD'
            }
        }

        stage('Push to Docker Hub') {
            steps {
                withCredentials([usernamePassword(credentialsId: 'your-credentials-id', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]) {
                    sh "docker login -u ${USERNAME} -p ${PASSWORD}"
                    sh 'docker push g0m0r0/greencap:latest'
                }
            }
        }

        stage('SonarQube analysis') {
            steps {
                withCredentials([string(credentialsId: 'sonar_credential', variable: 'SONAR_AUTH_TOKEN')]) {
                    withSonarQubeEnv(installationName: 'SonarServer') {
                        sh '''
                            if ! dotnet tool list --global | grep -q dotnet-sonarscanner; then
                            dotnet tool install --global dotnet-sonarscanner
                            fi
                            export PATH="$PATH:$HOME/.dotnet/tools"
                            dotnet sonarscanner begin /k:"GreenCap" /d:sonar.host.url="http://sonarqube:9000" /d:sonar.login="$SONAR_AUTH_TOKEN" /d:sonar.cs.analyzer.projectOutPath="/var/jenkins_home/.dotnet/tools/.store/dotnet-sonarscanner/5.13.0/dotnet-sonarscanner/5.13.0/tools/net5.0/any"
                            cd src && dotnet build GreenCap.sln
                            dotnet sonarscanner end /d:sonar.login="$SONAR_AUTH_TOKEN"
                        '''
                    }
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
            archiveArtifacts artifacts: 'target/*.exe', followSymlinks: false, onlyIfSuccessful: true
        }
        failure {
            emailext body: 'Your test has failed!',
            recipientProviders: [buildUser()], subject: 'Failed test', to: 'dimitrovdelyann@gmail.com'
            echo 'Failed!'
        }
    }
}
