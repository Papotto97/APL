package services

import (
	"log"
	"unictapl/config"
	"unictapl/models"
	"unictapl/utils"
)

func InsertNewSearch(search *models.Searches) string {
	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	if utils.IsUserEmpty(search.User) {
		return "User can't be null"
	}

	_, err := client.Database("APL").Collection("Favourites").InsertOne(ctx, search)
	if err != nil {
		log.Printf("Could not add Rating: %v", err)
		return "Could not add Rating"
	}

	return "Search inserted"
}
