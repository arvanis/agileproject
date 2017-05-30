angular
    .module('Blacksmith',[
    
    ])
    .controller('mainCtrl', mainCtrl);

mainCtrl.$inject = ['$scope'];

function mainCtrl($scope) {
    $scope.items = [
        {
            "id": 0, 
            "type": "weapon",
            "name": "Blada Sprawiedliwość"
        },
        {
            "id": 1,
            "type": "weapon",
            "name": "Harfa Elfów"
        },
        {
            "id": 2,
            "type": "armor",
            "name": "Szyszak Żalu"
        },
        {
            "id": 3,
            "type": "jewelery",
            "name": "Wisior"
        }
    ];

    $scope.categories = [
        {
            "id": 0,
            "type": "weapon",
            "name": "Broń"
        },
        {
            "id": 1,
            "type": "armor",
            "name": "Pancerz"
        },
        {
            "id": 2,
            "type": "jewelery",
            "name": "Bizuteria"
        }
    ];
}
;