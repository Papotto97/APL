package services

import (
	"go.mongodb.org/mongo-driver/bson"
	"log"
	"unictapl/config"
	"unictapl/models"
	"unictapl/utils"
)

func InsertNewSearch(search *models.Searches) models.ResponseDTO {
	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	if utils.IsUserEmpty(search.User) {
		return models.ResponseDTO{"User can't be null", 500}
	}

	_, err := client.Database("APL").Collection("Favourites").InsertOne(ctx, search)
	if err != nil {
		log.Printf("Could not add Rating: %v", err)
		return models.ResponseDTO{"Could not add search", 500}
	}

	return models.ResponseDTO{"Search added", 200}
}

func GetSearchByImdbId(imdbId string) (search models.Searches) {
	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("APL").Collection("Favourites").FindOne(ctx, bson.D{{"imdbId", imdbId}}).Decode(&search)
	if err != nil {
		return models.Searches{}
	}

	return search
}
