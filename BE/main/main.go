package main

import (
	"log"
	"net/http"
	"unictapl/models"
	"unictapl/services"
	"unictapl/utils"

	"github.com/gin-gonic/gin"
)

func handleGetMovie(c *gin.Context) {
	movieId := c.Param("movieId")
	if len(movieId) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "movieId not populated"})
		return
	}

	movie := services.FindMovieById(movieId)
	if utils.IsMovieEmpty(movie) {
		c.JSON(http.StatusNotFound, gin.H{"msg": "Movie not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"movie": movie})

}
func handleGetUserByUsername(c *gin.Context) {
	username := c.Param("username")
	if len(username) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}

	user := services.FindUserByUsername(username)
	if (models.User{}) == user {
		c.JSON(http.StatusNotFound, gin.H{"msg": "User not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"user": user})

}
func handleGetUserByUsernameAndPassword(c *gin.Context) {
	username := c.Param("username")
	password := c.Param("password")
	if len(username) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}
	if len(password) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "password not populated"})
		return
	}

	user := services.FindUserByUsernameAndPassword(username, password)
	if (models.User{}) == user {
		c.JSON(http.StatusNotFound, gin.H{"msg": "User not found"})
		return
	}
	c.JSON(http.StatusOK, user)

}
func handleGetUserByEmail(c *gin.Context) {
	email := c.Param("email")
	if len(email) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "email not populated"})
		return
	}

	user := services.FindUserByEmail(email)
	if (models.User{}) == user {
		c.JSON(http.StatusNotFound, gin.H{"msg": "User not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"user": user})

}

func handleGetAllMovies(c *gin.Context) {

	movies := services.FindAllMovies()
	c.JSON(http.StatusOK, gin.H{"movies": movies})

}
func handleGetAllUsers(c *gin.Context) {

	users := services.FindAllUsers()
	c.JSON(http.StatusOK, gin.H{"users": users})

}

func handleCreateMovie(c *gin.Context) {
	log.Printf("Start creating ")

	var movie models.Movie
	if err := c.ShouldBindJSON(&movie); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	id, err := services.CreateMovie(&movie)
	if len(err) == 0 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
		return
	}
	c.JSON(http.StatusOK, gin.H{"id": id, "msg": err})

}
func handleCreateUser(c *gin.Context) {
	log.Printf("Start creating user ")

	var user models.User
	if err := c.ShouldBindJSON(&user); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	id, err := services.CreateUser(&user)
	if len(err) == 0 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
		return
	}
	c.JSON(http.StatusOK, gin.H{"id": id, "msg": err})

}

func handleAddFavourites(c *gin.Context) {
	log.Printf("Start creating favourite")

	var favourite models.Favourites
	if err := c.ShouldBindJSON(&favourite); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	response := services.AddFavourite(&favourite)
	if response.Status == 500 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": response.ErrorMessage})
	} else if response.Status == 200 {
		c.JSON(http.StatusOK, gin.H{"msg": response.ErrorMessage})
	} else if response.Status == 400 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": response.ErrorMessage})
	}
	//if len(err) == 0 {
	//	c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
	//	return
	//}

}
func handleGetAllFavouritesByUsername(c *gin.Context) {
	username := c.Param("username")
	if len(username) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}

	favourites := services.FindAllFavouritesByUsername(username)

	if len(favourites) == 0 {
		c.JSON(http.StatusNotFound, gin.H{"msg": "Favourites not found"})
		return
	}
	c.JSON(http.StatusOK, favourites)

}
func handleGetAllFavouritesByUsernameAndImdbId(c *gin.Context) {
	username := c.Param("username")
	imdbId := c.Param("imdbId")
	if len(username) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}
	if len(imdbId) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "username not populated"})
		return
	}

	favourites := services.FindAllFavouritesByUsernameAndImdbId(username, imdbId)

	// if len(favourites) == 0 {
	// 	c.JSON(http.StatusNotFound, gin.H{"msg": "Favourites not found"})
	// 	return
	// }
	c.JSON(http.StatusOK, favourites)

}
func handleUpdateFavourites(c *gin.Context) {
	var favourite models.Favourites
	if err := c.ShouldBindJSON(&favourite); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	response := services.UpdateFavourite(&favourite)
	if response.Status == 500 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": response.ErrorMessage})
	} else if response.Status == 200 {
		c.JSON(http.StatusOK, gin.H{"msg": response.ErrorMessage})
	} else if response.Status == 400 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": response.ErrorMessage})
	}
	//if len(err) == 0 {
	//	c.JSON(http.StatusInternalServerError, gin.H{"msg": err})
	//	return
	//}
}

func handleInsertSearch(c *gin.Context) {
	var search models.Searches
	if err := c.ShouldBindJSON(&search); err != nil {
		log.Print(err)
		c.JSON(http.StatusBadRequest, gin.H{"msg": err})
		return
	}
	response := services.InsertNewSearch(&search)
	if response.Status == 500 {
		c.JSON(http.StatusInternalServerError, gin.H{"msg": response.ErrorMessage})
	} else if response.Status == 400 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": response.ErrorMessage})
	} else if response.Status == 200 {
		c.JSON(http.StatusOK, gin.H{"msg": response.ErrorMessage})
	}

}
func handleGetSearchByImdbId(c *gin.Context) {
	imdbId := c.Param("imdbId")
	if len(imdbId) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "imdbId not populated"})
		return
	}
	search := services.GetSearchByImdbId(imdbId)
	if (models.Searches{}) == search {
		c.JSON(http.StatusNotFound, gin.H{"msg": "Search not found"})
		return
	}
	c.JSON(http.StatusOK, search)

}

func main() {
	r := gin.Default()

	//movies routes
	r.PUT("/movie/", handleCreateMovie)
	r.GET("/movies/:movieId", handleGetMovie)
	r.GET("/movies/all", handleGetAllMovies)
	//users routes
	r.PUT("/user/", handleCreateUser)
	r.GET("/user/:username", handleGetUserByUsername)
	r.GET("/user/:username/:password", handleGetUserByUsernameAndPassword)
	r.GET("/users/email/:email", handleGetUserByEmail)
	r.GET("/users/all", handleGetAllUsers)
	//favourites routes
	r.PUT("/favourite/", handleAddFavourites)
	r.POST("/favourite/", handleUpdateFavourites)
	r.GET("/favourites/:username", handleGetAllFavouritesByUsername)
	r.GET("/favourites/:username/:imdbId", handleGetAllFavouritesByUsernameAndImdbId)
	//searches routes
	r.PUT("/search/", handleInsertSearch)
	r.GET("/search/:imdbId", handleGetSearchByImdbId)

	r.Run("localhost:8081")
}
