pipeline {
    agent any
    stages {
        stage('Get Code') {
            steps {
                git url: 'https://github.com/muhadh98/WeatherDashboard.git', branch: 'main'
            }
        }
        stage('Clean') {
            steps {
                bat 'dotnet clean WeatherDashboard.sln'
            }
        }
        stage('Get Packages') {
            steps {
                bat 'dotnet restore WeatherDashboard.sln'
            }
        }
        stage('Build App') {
            steps {
                bat 'dotnet build WeatherDashboard.sln --configuration Release'
            }
        }
        stage('Run Tests') {
            steps {
                bat 'dotnet test WeatherDashboard.Tests/WeatherDashboard.Tests.csproj --logger "trx;LogFileName=TestResults.xml"'
            }
        }
        stage('Publish Test Results') {
            steps {
                junit '**/TestResults/*.xml'
            }
        }
        stage('Prepare Files') {
            steps {
                bat 'dotnet publish WeatherDashboard/WeatherDashboard.csproj --configuration Release --output publish'
            }
        }
        stage('Save Files') {
            steps {
                archiveArtifacts artifacts: 'publish/**', allowEmptyArchive: true
            }
        }
    }
}
