package utils

import (
	"reflect"
	"unictapl/models"
)

func IsMovieEmpty(x models.Movie) bool {

	return reflect.DeepEqual(x, models.Movie{})

}
func IsUserEmpty(x models.User) bool {

	return reflect.DeepEqual(x, models.User{})

}
func IsFavouriteEmpty(x models.Favourites) bool {

	return reflect.DeepEqual(x, models.Favourites{})

}
