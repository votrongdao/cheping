angular.module('cheping', [
    'ionic',
    'ngCordova',
    'cheping.filters',
    'cheping.interceptors',
    'cheping.services',
    'cheping.services.user',
    'cheping.services.case'
])
    .constant('URLS', {
        USER: {
            GETINFO: 'http://cheping.chinacloudsites.cn:80/api/Users',
            SIGNIN: 'http://cheping.chinacloudsites.cn:80/api/Users/Login'
        },
        CASE: {
            GETCASELIST: 'http://cheping.yuyidev.com:80/api/Case/List',
            GETVEHICLEINFO: 'http://cheping.yuyidev.com:80/api/Case/VehicleInfo',
            GETTODOS: 'http://cheping.chinacloudsites.cn:80/api/Case/Todos'
        }
    })
    .config(function($ionicConfigProvider) {
        $ionicConfigProvider.views.transition('ios');
        $ionicConfigProvider.tabs.position('bottom');
        $ionicConfigProvider.backButton.text('').icon('ion-ios-arrow-back');
    })
    .config(function($httpProvider) {
        //$httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push('globalInterceptor');
        $httpProvider.interceptors.push('loadingInterceptor');
    })
    .config(function($compileProvider) {
        $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|file|blob|cdvfile):|data:image\//);
    })
    .config(function($stateProvider, $urlRouterProvider) {
        $stateProvider.state('cheping', {
            url: "",
            views: {
                '@': {
                    controller: 'MainCtrl as ctrl',
                    templateUrl: 'app/index.tpl.html'
                }
            }
        });

        $urlRouterProvider.otherwise('');
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
    })
    .run(function($rootScope, $ionicLoading) {
        $rootScope.$on('loading:show', function() {
            $ionicLoading.show({
                template: '<ion-spinner icon="spiral" class="spinner-energized"></ion-spinner>'
            });
        });

        $rootScope.$on('loading:hide', function() {
            $ionicLoading.hide();
        });

        $rootScope.$on('http:requestError', function() {
            $ionicLoading.hide();
            $ionicLoading.show({
                template: '请求失败',
                duration: 3000
            });
        });

        $rootScope.$on('http:responseError-500', function() {
            $ionicLoading.hide();
            $ionicLoading.show({
                template: '请稍后再试',
                duration: 3000
            });
        });
    })
    .controller('MainCtrl', function($state, UserService, UtilityService) {
        var ctrl = this;

        ctrl.showNewTab = false;
        ctrl.showWarningTab = false;

        UserService.getUserInfo()
            .then(function(result) {
                if (result.jobTitle === 40 || result.jobTitle === 50) {
                    ctrl.showNewTab = true;
                } else if (result.jobTitle === 10) {
                    ctrl.showNewTab = true;
                } else {
                    UtilityService.showAlert('请先登录');
                    $state.go('cheping.user-login');
                }
            });
    });

