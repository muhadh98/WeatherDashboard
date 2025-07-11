pipeline {
    agent any

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
                bat 'dotnet test WeatherDashboard.Tests/WeatherDashboard.Tests.csproj --logger "trx;LogFileName=TestResults.xml" --results-directory WeatherDashboard.Tests\\TestResults'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish WeatherDashboard/WeatherDashboard.csproj --configuration Release --output publish --no-build'
            }
        }

        stage('Deploy to Dev') {
            steps {
                bat 'robocopy publish "C:\\Users\\MUHADH\\Desktop\\Devops\\DevopsAsssesment\\dev" /MIR /NFL /NDL /NJH /NJS /NC /NS /NP /R:0 /W:0 || exit 0'
            }
        }

        stage('Deploy to Staging') {
            steps {
                bat 'robocopy publish "C:\\Users\\MUHADH\\Desktop\\Devops\\DevopsAsssesment\\staging" /MIR /NFL /NDL /NJH /NJS /NC /NS /NP /R:0 /W:0 || exit 0'
            }
        }

        stage('Deploy to Production') {
            steps {
                bat 'robocopy publish "C:\\Users\\MUHADH\\Desktop\\Devops\\DevopsAsssesment\\prod" /MIR /NFL /NDL /NJH /NJS /NC /NS /NP /R:0 /W:0 || exit 0'
            }
        }
    }

    post {
        success {
            echo 'Build succeeded!'
        }
    }
}
