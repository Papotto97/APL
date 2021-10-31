# APL Backend Module
## IDE setup (Goland from Intellij IDEA)
https://www.jetbrains.com/help/idea/quick-start-guide-goland.html#create-a-new-project
## Quick start with Go
### Install Go
https://golang.org/dl/

### Install Gin-Gonic Framework package with using the go command
```go 
go get github.com/gin-gonic/gin
```

### Go get some mod packages
Add gin-gonic mod gin
```go 
go mod download github.com/gin-gonic/gin
```
Add gin-gonic mod sse
```go 
go mod download github.com/gin-contrib/sse
```
Add go-playground mods
```go 
go mod download github.com/go-playground/validator/v10
```
```go 
go mod download github.com/go-playground/universal-translator
```
```go 
go mod download github.com/go-playground/locales
```
Add protobuf mod
```go 
go mod download github.com/golang/protobuf
```
Add leodido mod
```go 
go mod download github.com/leodido/go-urn
```
Add mattn go-isatty mod
```go 
go mod download github.com/mattn/go-isatty
```
Add codec mod
```go 
go mod download github.com/ugorji/go github.com/ugorji/go/codec
```
Add mongo drivers mod
```go 
go mod download go.mongodb.org/mongo-driver
```
Add go-stack mod
```go 
go mod download github.com/go-stack/stack
```
Add snappy mod
```go 
go mod download github.com/golang/snappy
```
Add klauspost mod
```go 
go mod download github.com/klauspost/compress
```
Add errors mod
```go 
go mod download github.com/pkg/errors
```
Add xdg-go mods
```go 
go mod download github.com/xdg-go/scram
```
```go 
go mod download github.com/xdg-go/pbkdf2
```
```go 
go mod download github.com/xdg-go/stringprep
```
Add youmark mod
```go 
go mod download github.com/youmark/pkcs8
```
Add x mods
```go 
go mod download golang.org/x/crypto
```
```go 
go mod download golang.org/x/sync
```
```go 
go mod download golang.org/x/text
```
Add gopkg mod
```go 
go mod download gopkg.in/yaml.v2
```

### Build
```go 
go build BE
```

### Run
```go 
go run
```
