package services

import (
	"context"
	"fmt"
	"go.mongodb.org/mongo-driver/bson"
	"log"
	"unictapl/config"
	"unictapl/models"
	"unictapl/utils"
)

func AddFavourite(favourite *models.Favourites) string {
	var results []models.Favourites
	var s models.Favourites

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)
	if favourite.Id == 0 {
		result, err := client.Database("unictapl").Collection("favourites").Find(ctx, bson.D{})
		if err != nil {
			log.Fatal(err)
			return "Cannot set Id"
		}
		for result.Next(context.TODO()) {
			//Create a value into which the single document can be decoded
			var fav models.Favourites
			err := result.Decode(&fav)
			if err != nil {
				log.Fatal(err)
			}

			results = append(results, fav)

		}
		favourite.Id = len(results)
	}

	if len(favourite.ImdbId) == 0 {
		return "ImdbId is empty"
	}

	if utils.IsUserEmpty(favourite.User) {
		return "User can't be null"
	}

	if favourite.PersonalRating == 0 {
		return "Personal Rating can't be 0"
	}

	if utils.IsMovieEmpty(FindMovieById(favourite.ImdbId)) {
		return "Movie doesn't exist on DB"
	}

	if utils.IsUserEmpty(FindUserById(favourite.User.UserId)) {
		return "User doesn't exist on DB"
	}

	res := client.Database("unictapl").Collection("favourites").FindOne(ctx, bson.D{{"imdbId", favourite.ImdbId}, {"user", favourite.User}})
	res.Decode(&s)
	if utils.IsFavouriteEmpty(s) {
		_, err := client.Database("unictapl").Collection("favourites").InsertOne(ctx, favourite)
		if err != nil {
			log.Printf("Could not add Rating: %v", err)
			return "Could not add Rating"
		}

		return "Rating correctly added"

	} else {
		return "Movie already added to favourites and rated: " + fmt.Sprintf("%f", s.PersonalRating)
	}

}

func FindAllFavouritesByUser(userId int) (favourites []models.Favourites) {
	var results []models.Favourites

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	result, err := client.Database("unictapl").Collection("favourites").Find(ctx, bson.D{{"user.userId", userId}})
	if err != nil {
		log.Fatal(err)
		return results
	}
	for result.Next(context.TODO()) {
		//Create a value into which the single document can be decoded
		var favourite models.Favourites
		err := result.Decode(&favourite)
		if err != nil {
			log.Fatal(err)
		}

		results = append(results, favourite)

	}
	return results
}
