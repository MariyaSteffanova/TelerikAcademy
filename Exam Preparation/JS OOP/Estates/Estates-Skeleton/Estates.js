function processEstatesAgencyCommands(commands) {
    var uniqueApartmentNames = [],
        uniqueOfficeNames = [],
        uniqueHouseNames = [],
        uniqueGarageNames = [];
    'use strict';
    function validateString(value) {
        if (!value) {
            return false;
        }
        return true;
    }

    function validateRange(value, min, max) {
        if (!value || isNaN(parseInt(value)) || value < min || value > max || value !== parseInt(value)) {
            return false;
        }
        return true;
    }

    function validateBoolean(value) {
        if (value === 'true' || value === true) {
            return true;
        }
        else if (value === 'false' || value === false) {
            return false;
        }
        throw  new Error('Invalid boolean!');
    }

    var Estate = (function () {
        var estate = {
            init: function (name, area, location, isFurnitured) {
                this.name = name;
                this.area = area;
                this.location = location;
                this.isFurnitured = isFurnitured;
                return this;
            },
            toString: function () {
                var result = '';
                result += this.type;
                result += ' Name = ' + this.name + ',';
                result += ' Area = ' + this.area + ',';
                result += ' Location = ' + this.location + ',';
                result += ' Furnitured = ' + (this.isFurnitured ? 'Yes,' : 'No,');
                return result;
            }
        }


        Object.defineProperty(estate, 'name', {
            get: function () {
                return this._name;
            },
            set: function (value) {
                if (validateString(value)) {
                    this._name = value;
                }
                else {
                    throw new Error('Invalid name!');
                }
            }
        }),

            Object.defineProperty(estate, 'area', {
                get: function () {
                    return this._area;
                },
                set: function (value) {
                    if (validateRange(value, 1, 10000)) {
                        this._area = value;
                    }
                    else {
                        throw new Error('Invalid Area!');
                    }
                }
            }),

            Object.defineProperty(estate, 'location', {
                get: function () {
                    return this._location;
                },
                set: function (value) {
                    if (validateString(value)) {
                        this._location = value;
                    }
                    else {
                        throw  new Error('Invalid location!');
                    }
                }
            }),
            Object.defineProperty(estate, 'isFurnitured', {
                get: function () {
                    return this._isFurnitured;
                },
                set: function (value) {
                    this._isFurnitured = validateBoolean(value);
                }
            })

        return estate;
    }());

    var BuildingEstate = (function (parent) {
        var buildingEstate = Object.create(parent, {
            init: {
                value: function (name, area, location, isFurnitured, numberOfRooms, hasElevator) {
                    parent.init.call(this, name, area, location, isFurnitured);
                    this.rooms = numberOfRooms;
                    this.hasElevator = hasElevator;
                    return this;
                }
            },
            toString: {
                value: function () {
                    var result = parent.toString.call(this);

                    result += ' Rooms: ' + this.rooms + ',';
                    result += ' Elevator: ' + (this.hasElevator ? 'Yes' : 'No');

                    return result;
                }
            }
        });
        Object.defineProperty(buildingEstate, 'rooms', {
            get: function () {
                return this._rooms;
            },
            set: function (value) {
                if (validateRange(value, 0, 100)) {
                    this._rooms = value;
                }
                else {
                    throw  new Error('Invalid number of rooms!');
                }
            }
        })

        Object.defineProperty(buildingEstate, 'hasElevator', {
            get: function () {
                return this._hasElevator;
            },
            set: function (value) {
                this._hasElevator = validateBoolean(value);
            }
        })

        return buildingEstate;
    }(Estate));

    var Apartment = (function (parent) {
        var apartment = Object.create(parent, {
            init: {

                value: function (name, area, location, isFurnitured, numberOfRooms, hasElevator) {
                    /*var checkUnique  = uniqueApartmentNames.filter(function(ap){
                        return app.name === name;
                    });
                    if(checkUnique){
                        throw new Error('Repeating names.')
                    }*/
                    parent.init.call(this, name, area, location, isFurnitured, numberOfRooms, hasElevator);
                    this.type = 'Apartment:';
                    uniqueApartmentNames.push(name);
                    return this;
                }
            }

        });

        return apartment;

    }(BuildingEstate));

    var Office = (function (parent) {
        var office = Object.create(parent, {
            init: {
                value: function (name, area, location, isFurnitured, numberOfRooms, hasElevator) {
                    parent.init.call(this, name, area, location, isFurnitured, numberOfRooms, hasElevator);
                    this.type = 'Office:';
                    return this;
                }
            }
        });

        return office;
    }(BuildingEstate));

    var House = (function (parent) {
        var house = Object.create(parent, {
            init: {
                value: function (name, area, location, isFurnitured, numberOfFloors) {
                    parent.init.call(this, name, area, location, isFurnitured);
                    this.floors = numberOfFloors;
                    this.type = 'House:';
                    return this;
                }
            },
            toString: {
                value: function () {
                    var result = parent.toString.call(this);

                    result += ' Floors: ' + this.floors;
                    return result;
                }
            }
        });

        Object.defineProperty(house, 'floors', {
            get: function () {
                return this._floors;
            },
            set: function (value) {
                if (validateRange(value, 1, 10)) {
                    this._floors = value;
                }
                else {
                    throw  new Error('Invalid number of floors!');
                }
            }
        })

        return house;
    }(Estate));

    var Garage = (function (parent) {
        var garage = Object.create(parent, {
            init: {
                value: function (name, area, location, isFurnitured, width, height) {
                    parent.init.call(this, name, area, location, isFurnitured);
                    this.width = width;
                    this.height = height;
                    this.type = 'Garage:';
                    return this;
                }
            },
            toString: {
                value: function () {
                    var result = parent.toString.call(this);

                    result += ' Width: ' + this.width + ',';
                    result += ' Height: ' + this.height;

                    return result;
                }
            }
        });
        Object.defineProperty(garage, 'width', {
            get: function () {
                return this._width;
            },
            set: function (value) {
                if (validateRange(value, 1, 500)) {
                    this._width = value;
                }
                else {
                    throw new Error('Invalid width!');
                }
            }
        }),
            Object.defineProperty(garage, 'height', {
                get: function () {
                    return this._height;
                },
                set: function (value) {
                    if (validateRange(value, 1, 500)) {
                        this._height = value;
                    }
                    else {
                        throw new Error('Invalid height!');
                    }
                }
            })


        return garage;
    }(Estate));

    var Offer = (function () {
        var offer = {
            init: function (estate, price) {
                this.estate = estate;
                this.price = price;
                return this;
            },
            toString: function () {
                //Rent: Estate = aptLozenec24, Location = Sofia, Price = 750
                //Sale: Estate = aptLozenec24, Location = Sofia, Price = 195000
                var offerToStr = '';
                offerToStr += this.type;
                offerToStr += ' Estate = ' + this.estate.name + ',';
                offerToStr += ' Location = ' + this.estate.location + ',';
                offerToStr += ' Price = ' + this.price;
                return offerToStr;

            }
        }

        Object.defineProperty(offer, 'price', {
            get: function () {
                return this._price;
            },
            set: function (value) {
                if (validateRange(value, 1, 80000000000)) {
                    this._price = value;
                }
                else {
                    throw  new Error('Invalid price!');
                }

            }
        }),

            Object.defineProperty(offer, 'estate', {
                get: function () {
                    return this._estate;
                },
                set: function (value) {
                    this._estate = value;
                    this._estate.name = value.name;
                    this._estate.location = value.location;
                }
            })


        return offer;
    }());

    var RentOffer = (function (parent) {
        var rentOffer = Object.create(parent, {
            init: {
                value: function (estate, price) {
                    parent.init.call(this, estate, price);
                    this.type = 'Rent:';
                    return this;
                }
            }
        });

        return rentOffer;
    }(Offer));

    var SaleOffer = (function (parent) {
        var saleOffer = Object.create(parent, {
            init: {
                value: function (estate, price) {
                    parent.init.call(this, estate, price);
                    this.type = 'Sale:';
                    return this;
                }
            }
        });
        return saleOffer;
    }(Offer));

    var EstatesEngine = (function () {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function isValidArgument(value) {
            if (value === undefined || value != parseInt(value)) { // check for <0 ?!{
                return false;
            }
            return true;
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
                case 'create':
                    return executeCreateCommand(cmdArgs);
                case 'status':
                    return executeStatusCommand();
                case 'find-sales-by-location':
                    return executeFindSalesByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-location':
                    return executeFindRentsByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-price':
                    return executeFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                default:
                    throw new Error('Unknown command: ' + cmdName);
            }
        }


        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
                case 'Apartment':
                    var apartment = Object.create(Apartment)
                        .init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(apartment);

                    break;
                case 'Office':
                    var office = Object.create(Office)
                        .init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(office);
                    break;
                case 'House':
                    var house = Object.create(House)
                        .init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                    addEstate(house);
                    break;
                case 'Garage':
                    var garage = Object.create(Garage)
                        .init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                    addEstate(garage);
                    break;
                case 'RentOffer':
                    var estate = findEstateByName(cmdArgs[1]);
                    var rentOffer = Object.create(RentOffer)
                        .init(estate, Number(cmdArgs[2]));
                    addOffer(rentOffer);
                    break;
                case 'SaleOffer':
                    estate = findEstateByName(cmdArgs[1]);
                    var saleOffer = Object.create(SaleOffer)
                        .init(estate, Number(cmdArgs[2]));
                    addOffer(saleOffer);
                    break;
                default:
                    throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].name == estateName) {
                    //console.log(_estates[i]);
                    return _estates[i];
                }
            }
            throw new Error('Estate cannot be undefined');
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.name]) {
                throw new Error('Duplicated estate name: ' + estate.name);
            }
            _uniqueEstateNames[estate.name] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {

                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function (offer) {
                return offer.estate.location === location && Object.getPrototypeOf(offer) === SaleOffer; // Here
            });
            selectedOffers.sort(function (a, b) {
                return a.estate.name.localeCompare(b.estate.name);
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByLocationCommand(location) {
            if (!location) {
                throw  new Error("Location cannot be empty.");
            }

            var filtredRentOffers = _offers.filter(function (offer) {
                return offer.estate.location === location &&
                    Object.getPrototypeOf(offer) === RentOffer;
            });

            filtredRentOffers.sort(function (a, b) {
                return a.estate.name > b.estate.name;
            });

            return formatQueryResults(filtredRentOffers);
        }

        function executeFindRentsByPriceCommand(minPrice, maxPrice) {
            var args = arguments;
            if (args.length !== 2 || !isValidArgument(args[0]) || !isValidArgument(args[1])) {
                throw new Error('Invalid arguments!');
            }
            var filtredRentOffersByPrice = _offers.filter(function (offer) {
                return Object.getPrototypeOf(offer) === RentOffer && offer.price >= minPrice && offer.price <= maxPrice;
            });
            filtredRentOffersByPrice = filtredRentOffersByPrice.sort(function (a, b) {
                return a.estate.name > b.estate.name;
            });
            filtredRentOffersByPrice = filtredRentOffersByPrice.sort(function (a, b) {
                return a.price > b.price;
            });


            return formatQueryResults(filtredRentOffersByPrice);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length == 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.estate.name +
                        ', Location: ' + offer.estate.location +
                        ', Price: ' + offer.price + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


// Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    //console.log(comands);
    /*if (commands === undefined) {
     return;
     }*/
    commands = commands || [];
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results;

}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

