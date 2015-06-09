angular.module('cheping', [
    'ionic',
    'ngCordova',
    'ngMessages',
    'cheping.index',
    'cheping.user'
])
    .config(function($stateProvider, $urlRouterProvider) {
        $stateProvider.state('cheping', {
            url: "",
            abstract: true
        });

        $urlRouterProvider.otherwise('/index/todos');
    })
    .run(function($ionicPlatform) {
        $ionicPlatform.ready(function() {
            if (window.cordova && window.cordova.plugins.Keyboard) {
                cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
                cordova.plugins.Keyboard.disableScroll(true);
            }
            if (window.StatusBar) {
                StatusBar.styleDefault();
            }
        });
    });

