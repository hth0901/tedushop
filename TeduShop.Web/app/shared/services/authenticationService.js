﻿/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    'user strict';
    app.service('authenticationService', ['$http', '$q', '$window',
        function ($http, $q, $window) {     //$q: service thuc thi doi tuong promise, window
            var tokenInfo;
            this.setTokenInfo = function (data) {
                tokenInfo = data;
                $window.sessionStorage["TokenInfo"] = JSON.stringify(tokenInfo);
            };

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeTokenInfo = function () {
                tokenInfo = null;
                $window.sessionStorage["TokenInfo"] = null;
            }

            this.init = function () {
                if ($window.sessionStorage["TokenInfo"]) {
                    tokenInfo = JSON.parse($window.sessionStorage["TokenInfo"]);
                }
            }


            //gán header của token
            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            this.validateRequest = function () {
                var url = '/api/home/TestMethod';
                var deferred = $q.defer();
                $http.get(url).then(function () {
                    deferred.resolve(null);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            this.init();
        }
    ])
})(angular.module('tedushop.common'));