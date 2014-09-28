'use strict';

/* Services */


// Demonstrate how to register services
var appService = angular.module('app.services', []);

appService.factory("dataService", [
    "$http", "$q", function($http, $q) {

        var _landLords = [];

        var _isInit = false;

        var _isReady = function() {
            return _isInit;
        }

        var _getLandLords = function() {

            var deferred = $q.defer();

            $http.get("/api/v1/landlords/")
                .then(function(result) {
                        angular.copy(result.data, _landLords);
                        _isInit = true;
                        deferred.resolve();
                    },
                    function() {
                        deferred.reject();
                    }
                );
            return deferred.promise;
        };

        var _addLandlord = function(newLandlord) {

            var deferred = $q.defer();

            $http.post("/api/v1/landlords", newLandlord)
                .then(function(result) {
                        //success
                        var newlyCreatedLandlord = result.data;
                        _landLords.splice(0, 0, newlyCreatedLandlord);
                        deferred.resolve(newLandlord);
                    },
                    function() {
                        deferred.reject();
                    });

            return deferred.promise;
        };

        return {
            landlord: _landLords,
            getLandlords: _getLandLords,
            addLandlord: _addLandlord,
            isReady: _isReady,
        }
    }]);