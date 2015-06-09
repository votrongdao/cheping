angular.module('cheping.index', [
    'cheping.index.todo',
    'cheping.index.orders',
    'cheping.index.create',
    'cheping.services.cache'
])
    .config(function ($stateProvider) {
        $stateProvider
            .state('cheping.index', {
                url: '/index',
                abstract: true,
                views: {
                    'cheping@': {
                        controller: 'ChepingCtrl as chepingCtrl',
                        templateUrl: 'app/index/index.tpl.html'
                    }
                }
            })
    })
    .controller('ChepingCtrl', function(ChepingAuthService) {
        var chepingCtrl = this;
        ChepingAuthService.getUser();
    });
