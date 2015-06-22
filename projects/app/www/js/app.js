// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.services' is found in services.js
// 'starter.controllers' is found in controllers.js
angular.module('cheping', ['ionic', 'cheping.controllers', 'cheping.services', 'ngCordova'])

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

    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider

    // setup an abstract state for the tabs directive
        .state('tabs', {
        url: "/tabs",
        abstract: true,
        templateUrl: "templates/tabs.html"
    })

    // Each tab has its own nav history stack:

    .state('tabs.todos', {
            url: '/todos',
            views: {
                'tabs.todos': {
                    templateUrl: 'templates/tabs.todos.html',
                    controller: 'TodosCtrl'
                }
            }
        })
        .state('tabs.todoDetail', {
            url: '/todos/{orderNo}',
            views: {
                'tabs.todos': {
                    templateUrl: 'templates/todoDetail.html',
                    controller: 'TodoDetailCtrl'
                }
            }
        })

    .state('tabs.orders', {
            url: '/orders',
            views: {
                'tabs.orders': {
                    templateUrl: 'templates/tabs.orders.html',
                    controller: 'OrdersCtrl'
                }
            }
        })
        .state('tabs.orderDetail', {
            url: '/orders/{orderNo}',
            views: {
                'tabs.orders': {
                    templateUrl: 'templates/orderDetail.html',
                    controller: 'OrderDetailCtrl'
                }
            }
        })
        .state('tabs.newOrder', {
            url: '/newOrder',
            views: {
                'tabs.newOrder': {
                    templateUrl: 'templates/tabs.newOrder.html',
                    controller: 'NewOrderCtrl'
                }
            }
        });

    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/tabs/todos');

});

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.services' is found in services.js
// 'starter.controllers' is found in controllers.js
//angular.module('cheping', ['ionic', 'cheping.controllers', 'cheping.services'])
//
//  .run(function($ionicPlatform) {
//    $ionicPlatform.ready(function() {
//      // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
//      // for form inputs)
//      if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
//        cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
//        cordova.plugins.Keyboard.disableScroll(true);
//      }
//      if (window.StatusBar) {
//        // org.apache.cordova.statusbar required
//        StatusBar.styleLightContent();
//      }
//    });
//  })
//
//  .config(function($stateProvider, $urlRouterProvider) {
//    $urlRouterProvider.otherwise("/toDos");
//
//    $stateProvider.state("tabs", {
//      url: "/",
//      abstract: true,
//      templateUrl: "templates/tabs.html"
//    })
//      .state("tabs.toDos", {
//        resolve: {
//          toDos: function(OrderService) {
//            return OrderService.getTodos();
//          }
//        },
//        url: "/toDos",
//        templateUrl: "templates/tabs.toDos.html",
//        controller: "TodosCtrl"
//      })
//      .state("tabs.orders", {
//        resolve: {
//          orders: function(OrderService) {
//            return OrderService.getOrders();
//          }
//        },
//        url: '/orders',
//        templateUrl: "templates/tabs.orders.html",
//        controller: "OrdersCtrl"
//      })
//      .state('tabs.newOrder', {
//        resolve: {
//          carTypes: function(ConfigService) {
//            return ConfigService.carTypes;
//          }
//        },
//        url: '/newOrder',
//        templateUrl: "templates/tabs.newOrder.html",
//        controller: "NewOrderCtrl"
//      });
//
//  });
