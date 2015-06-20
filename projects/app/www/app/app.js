angular.module('cheping', [
    'ionic',
    'ngCordova'
])
    .constant('URLS', {
        CONFIG: {
            FETCH: 'https://jymstoredev.blob.core.chinacloudapi.cn/publicfiles/Configs/AppConfig/3.0.0'
        },
        JINBOAYIN: {
            FETCH: 'https://jym-dev-api.jinyinmao.com.cn/Product/Current/JBY'
        },
        INVESTING: {
            JBY: 'https://jym-dev-api.jinyinmao.com.cn/Investing/JBY'
        },
        USER: {
            GETINFO: 'https://jym-dev-api.jinyinmao.com.cn/User',
            SIGNIN: 'https://jym-dev-api.jinyinmao.com.cn/User/Auth/SignIn'
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
            url: "/index",
            abstract: true,
            views: {
                '@': {
                    controller: 'MainCtrl as ctrl',
                    templateUrl: 'app/index.tpl.html'
                }
            }
        });

        $urlRouterProvider.otherwise('/jinbaoyin');
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
            $ionicLoading.show({
                template: '请求失败',
                duration: 3000
            });
        });

        $rootScope.$on('http:responseError-500', function() {
            $ionicLoading.show({
                template: '请稍后再试',
                duration: 3000
            });
        });
    });

