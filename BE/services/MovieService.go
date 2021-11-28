package services

import (
	"context"
	"log"
	"math/rand"
	"unictapl/config"
	"unictapl/models"
	"unictapl/utils"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
)

func CreateMovie(movie *models.Movie) (primitive.ObjectID, string) {
	var s models.Movie

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)
	if len(movie.ImdbId) == 0 {
		movie.ImdbId = RandomString(10)
	}

	res := client.Database("APL").Collection("Movies").FindOne(ctx, bson.D{{"imdbId", movie.ImdbId}})
	res.Decode(&s)
	if utils.IsMovieEmpty(s) {
		result, err := client.Database("APL").Collection("Movies").InsertOne(ctx, movie)
		if err != nil {
			log.Printf("Could not create Movie: %v", err)
			return result.InsertedID.(primitive.ObjectID), "Could not create Movie"
		}

		return result.InsertedID.(primitive.ObjectID), "Movie correctly added"

	} else {
		return primitive.ObjectID{}, "Already on DB"
	}

}
func FindMovieById(movieId string) (movie models.Movie) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("APL").Collection("Movies").FindOne(ctx, bson.D{{"imdbId", movieId}}).Decode(&movie)
	if err != nil {
		return models.Movie{}
	}
	return movie
}
func FindAllMovies() (movies []models.Movie) {
	var results []models.Movie

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	result, err := client.Database("APL").Collection("Movies").Find(ctx, bson.D{})
	if err != nil {
		log.Fatal(err)
		return results
	}
	for result.Next(context.TODO()) {
		//Create a value into which the single document can be decoded
		var movie models.Movie
		err := result.Decode(&movie)
		if err != nil {
			log.Fatal(err)
		}

		results = append(results, movie)

	}
	return results
}

func RandomString(n int) string {
	var letters = []rune("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
	s := make([]rune, n)
	for i := range s {
		s[i] = letters[rand.Intn(len(letters))]
	}
	return string(s)
}
