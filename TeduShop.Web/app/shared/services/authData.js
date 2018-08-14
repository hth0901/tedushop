// chua thong tin authen khi dang nhap xong
// cach viet moi
(function (app) {
    'user strict';
    app.factory('authData', [
        function () {
            var authDataFactory = {};
            var authentication = {
                IsAuthenticated: false,
                userName: '',
            };
            authDataFactory.authenticationData = authentication;
            return authDataFactory;
        }
    ])
})(angular.module('tedushop.common'));