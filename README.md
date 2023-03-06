# Hadur
A CI/CD pipeline system built to work with native K8S system while working on a module system of Anisible. 

# Requirements

## Documentation
 - Draw.IO / Diagrams.Net : To view diagrams / UML Charts

# Architecture

In the main Hadur architecture, we have the high level view. The main points are as follows:

- UI / API: Main frontend interface where user(s) will interact with the system to perform CRUD operations on pipelines
- K8S API: Native Kubernetes API that will be used to launch jobs based on pipelines
- Redis: To be used for caching purposes and other information to be held in memory
- Kafka: Place to store and consume logs and other information to be streamed from jobs
- Postgres: Database, to be used for storage of information