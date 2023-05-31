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
        
        stage('SonarQube analysis') {
            steps {
                withCredentials([string(credentialsId: 'sonar_credential', variable: 'SONAR_AUTH_TOKEN')]) {
                    withSonarQubeEnv(installationName: 'SonarServer') {
                        sh '''
                            if ! dotnet tool list --global | grep -q dotnet-sonarscanner; then
                            dotnet tool install --global dotnet-sonarscanner
                            fi
                            export PATH="$PATH:$HOME/.dotnet/tools"
                            dotnet sonarscanner begin /k:"GreenCap" /d:sonar.host.url="http://sonarqube:9000"  /d:sonar.login="$SONAR_AUTH_TOKEN"
                            cd src && dotnet build GreenCap.sln
                            dotnet sonarscanner end /d:sonar.login="$SONAR_AUTH_TOKEN"
                        '''
                    }
                }
            }
        }

        // stage('SonarQube Analysis') {
        //     steps {
        //         withCredentials([string(credentialsId: 'sonar_credential', variable: 'SONAR_AUTH_TOKEN')]) {
        //             withSonarQubeEnv(installationName: 'SonarServer') {
        //                 def scannerHome = tool 'SonarScanner for MSBuild'
        //                 withSonarQubeEnv() {
        //                     sh '''
        //                         dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"GreenCap\" /d:sonar.host.url="http://sonarqube:9000"  /d:sonar.login="$SONAR_AUTH_TOKEN
        //                         cd src && dotnet build
        //                         dotnet ${scannerHome}/SonarScanner.MSBuild.dll end /d:sonar.login="$SONAR_AUTH_TOKEN
        //                     '''
        //                 }
        //             }
        //         }
        //     }
        // }
        
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
