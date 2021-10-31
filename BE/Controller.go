package BE

import (
	"github.com/gin-gonic/gin"
	"log"
	"net/http"
	"unictapl/models"
	"unictapl/services"
)

func HandleGetMovie(c *gin.Context) {
	movieId := c.Param("movieId")
	if len(movieId) == 0 {
		c.JSON(http.StatusBadRequest, gin.H{"msg": "movieId not populated"})
		return
	}

	movie := services.FindById(movieId)
	if (models.Movie{}) == movie {
		c.JSON(http.StatusNotFound, gin.H{"msg": "Movie not found"})
		return
	}
	c.JSON(http.StatusOK, gin.H{"movie": movie})

}

func HandleGetAllMovies(c *gin.Context) {

	movie := services.FindAll()
	c.JSON(http.StatusOK, gin.H{"movie": movie})

}

func HandleCreateMovies(c *gin.Context) {
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
