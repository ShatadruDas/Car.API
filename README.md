# Car API

A lightweight car information service built with .NET 10. The API provides
generated vehicle details through a simple REST endpoint and includes
Swagger documentation, Docker support, GitHub Actions CI, and Kubernetes deployment
manifests for Minikube.

## Requirements

- .NET 10 SDK
- Docker Desktop for container builds
- Minikube and `kubectl` for Kubernetes deployment

## Run locally

From the repository root:

```powershell
dotnet restore Test.API.sln
dotnet build Test.API.sln
dotnet run --project Car.API/SD.Car.API.csproj --launch-profile Test.API
```

The API listens on `https://localhost:5001` and `http://localhost:5000` when the
`Test.API` launch profile is used. Swagger UI is available at `/swagger` in the
Development environment.

To run from the project directory instead:

```powershell
dotnet run --launch-profile Test.API
```

## API

### Get car details

```http
GET /CarDetails
```

The endpoint returns six generated records. Each record contains `id`, `name`,
`price`, `color`, and `topSpeed`.

Example:

```powershell
Invoke-RestMethod http://localhost:5000/CarDetails
```

## Docker

Build and run the image from the repository root:

```powershell
docker build -f Car.API/Dockerfile -t carapi:latest .
docker run --rm -p 8080:80 carapi:latest
```

## Minikube

Start Minikube, build the image in Minikube's image store, and apply the manifests:

```powershell
minikube start --driver=docker
minikube image build -t carapi:latest .
kubectl apply -f Car.API/deployment.yml
kubectl apply -f Car.API/deployment.services.yml
minikube service carapi --url
```

The Kubernetes service is exposed as a `NodePort` on port `30080`.

## CI

GitHub Actions restores, builds, and tests the solution using the .NET 10 SDK.

