package services

import (
	"context"
	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"log"
	"strings"
	"unictapl/config"
	"unictapl/models"
)

func CreateUser(user *models.User) (primitive.ObjectID, string) {
	var s models.User
	var r models.User
	var q models.User

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)
	if len(user.Username) == 0 {
		user.Username = RandomUsername(user.Email)
	}

	res := client.Database("unictapl").Collection("users").FindOne(ctx, bson.D{{"email", user.Email}})
	res.Decode(&s)
	if user.Email == s.Email {
		return primitive.ObjectID{}, "Already on DB"
	}

	ris := client.Database("unictapl").Collection("users").FindOne(ctx, bson.D{{"username", user.Username}})
	ris.Decode(&r)
	if user.Username == r.Username {
		return primitive.ObjectID{}, "Username already used"
	}
	risp := client.Database("unictapl").Collection("users").FindOne(ctx, bson.D{{"userId", user.UserId}})
	risp.Decode(&q)
	if user.UserId == q.UserId {
		return primitive.ObjectID{}, "UserId already used"
	}
	result, err := client.Database("unictapl").Collection("users").InsertOne(ctx, user)
	if err != nil {
		log.Printf("Could not create Movie: %v", err)
		return result.InsertedID.(primitive.ObjectID), "Could not create User"
	}

	return result.InsertedID.(primitive.ObjectID), "User correctly added"

}

func FindUserById(userId int) (user models.User) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("unictapl").Collection("users").FindOne(ctx, bson.D{{"userId", userId}}).Decode(&user)
	if err != nil {
		return models.User{}
	}
	return user
}
func FindUserByUsername(username string) (user models.User) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("unictapl").Collection("users").FindOne(ctx, bson.D{{"username", username}}).Decode(&user)
	if err != nil {
		return models.User{}
	}
	return user
}
func FindUserByEmail(email string) (user models.User) {

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	err := client.Database("unictapl").Collection("users").FindOne(ctx, bson.D{{"email", email}}).Decode(&user)
	if err != nil {
		return models.User{}
	}
	return user
}

func FindAllUsers() (users []models.User) {
	var results []models.User

	client, ctx, cancel := config.GetConnection()
	defer cancel()
	defer client.Disconnect(ctx)

	result, err := client.Database("unictapl").Collection("users").Find(ctx, bson.D{})
	if err != nil {
		log.Fatal(err)
		return results
	}
	for result.Next(context.TODO()) {
		//Create a value into which the single document can be decoded
		var user models.User
		err := result.Decode(&user)
		if err != nil {
			log.Fatal(err)
		}

		results = append(results, user)

	}
	return results
}

func RandomUsername(email string) string {
	return strings.Split(email, "@")[0]
}
