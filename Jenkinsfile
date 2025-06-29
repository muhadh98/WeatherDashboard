pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/muhadh98/WeatherDashboard.git', branch: 'main'
            }
        }
        stage('Restore') {
            steps {
                bat 'dotnet restore WeatherDashboard.sln'
            }
        }
        stage('Build') {
            steps {
                bat 'dotnet build WeatherDashboard.sln --configuration Release --no-restore'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test WeatherDashboard.Tests/WeatherDashboard.Tests.csproj --logger "trx;LogFileName=TestResults.xml" --results-directory WeatherDashboard.Tests/TestResults'
            }
        }
        stage('Code Analysis') {
            steps {
                echo 'Code analysis step (add your tool, e.g., SonarQube, here)'
                // Example: bat 'dotnet sonarscanner begin ...'
            }
        }
        stage('Security Scan') {
            steps {
                echo 'Security scan step (add your tool, e.g., Snyk, here)'
                // Example: bat 'snyk test'
            }
        }
        stage('Publish') {
            steps {
                bat 'dotnet publish WeatherDashboard/WeatherDashboard.csproj --configuration Release --output publish --no-build'
            }
        }
        stage('Deploy to Dev') {
            steps {
                bat 'robocopy publish "C:\\Users\\MUHADH\\Desktop\\Devops\\DevopsAsssesment\\dev" /MIR'
            }
        }
        stage('Deploy to Staging') {
            steps {
                bat 'robocopy publish "C:\\Users\\MUHADH\\Desktop\\Devops\\DevopsAsssesment\\staging" /MIR'
            }
        }
        stage('Deploy to Production') {
            steps {
                bat 'robocopy publish "C:\\Users\\MUHADH\\Desktop\\Devops\\DevopsAsssesment\\prod" /MIR'
            }
        }
    }

    post {
        always {
            junit 'WeatherDashboard.Tests/TestResults/*.xml'
            archiveArtifacts artifacts: 'publish/**', allowEmptyArchive: false
            cleanWs()
        }
    }