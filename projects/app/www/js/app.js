// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.services' is found in services.js
// 'starter.controllers' is found in controllers.js
angular.module('myCar', ['ionic'])

.run(function($ionicPlatform) {
    $ionicPlatform.ready(function() {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
        // for form inputs)
        if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            cordova.plugins.Keyboard.disableScroll(true);
        }
        if (window.StatusBar) {
            // org.apache.cordova.statusbar required
            StatusBar.styleLightContent();
        }
    });
})

.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    // $stateProvider.state('tab', {
    //         url: "/tabs",
    //         abstract: true,
    //         templateUrl: "templates/tabs.html"
    //     })
    //     .state('tab.toDos', {
    //         url: '/toDos',
    //         templateUrl: "templates/tab.toDos.html"
    //     })
    //     .state('tab.orders', {
    //         url: '/orders',
    //         templateUrl: "templates/tab.orders.html"
    //     })
    //     .state('tab.newOrder', {
    //         url: '/newOrder',
    //         templateUrl: "templates/tab.newOrder.html"
    //     });


    $stateProvider.state('toDos', {
        url: '/toDos',
        views: {
            toDos: {
                templateUrl: 'toDos.html'
            }
        }
    })

    $stateProvider.state('orders', {
        url: '/orders',
        views: {
            orders: {
                templateUrl: 'orders.html'
            }
        }
    })

    $stateProvider.state('newOrder', {
        url: '/newOrder',
        views: {
            newOrder: {
                templateUrl: 'newOrder.html'
            }
        }
    })

});
