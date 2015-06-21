angular.module('cheping.case', [
    'cheping.services.user'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.case', {
                url: '/case',
                views: {
                    'cases': {
                        controller: 'CaseCtrl as ctrl',
                        templateUrl: 'app/case/index.tpl.html'
                    }
                }
            })
    })
    .controller('CaseCtrl', function(UserService) {
        UserService.getUserInfo();
    });