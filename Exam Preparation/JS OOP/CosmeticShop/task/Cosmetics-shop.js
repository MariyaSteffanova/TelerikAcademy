function solve() {
    var cosmeticShop = function () {

        var Category = (function () {
            var category = {
                init: function (name) {
                    this.name = name;
                    return this;
                },
                addCosmetics: function (cosmetics) {
                    this.cosmetics = cosmetics;
                    return this;
                },
                removeCosmetics: function (cosmetics) {
                    var indexOfCosmeticsToRemove = this.cosmetics.indexOf(cosmetics);
                    this.cosmetics.splice(indexOfCosmeticsToRemove, 1);
                    return this;
                },
                print: function () {
                    if (!this.cosmetics) {
                        return this.name + ' category - ' + 0 + ' products it total';
                    }

                    var result = this.name + ' category - ' + this.cosmetics.length + ' products it total';

                    this.cosmetics.forEach(function (product) {
                        result += '\n- ' + product.brand + ' - ' + product.name;
                        result += '\n* Price: ' + product.price;
                        result += '\n* For gender: ' + product.gender;
                        if (Object.getPrototypeOf(product) == Shampoo) {
                            result += '\n* Quantity: ' + product.milliliters + 'ml';
                            result += '\n* Usage: ' + product.usage;
                        }
                        if (Object.getPrototypeOf(product) == Toothpaste) {
                            result += '\n* Ingredients: ' + product.ingredients;
                        }
                        result += '\n';
                    });

                    return result;
                }
            }

            Object.defineProperty(category, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (name) {
                    if (!name || name.length < 2 || name.length > 15) {
                        throw  new Error('Category name must be between 2 and 15 symbols long!');
                    }
                    this._name = name;
                }
            }),
                Object.defineProperty(category, 'cosmetics', {
                    get: function () {
                        return this._cosmetics;
                    },
                    set: function (value) {
                        this._cosmetics = this._cosmetics || [];
                        this._cosmetics.push(value);
                    }
                })

            return category;
        }());

        var Product = (function () {
            var product = {
                init: function (name, brand, price, gender) {
                    this.name = name;
                    this.brand = brand;
                    this.price = price;
                    this.gender = gender;
                    return this;
                }
            }

            Object.defineProperty(product, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (name) {
                    if (!name || name.length < 3 || name.length > 20) {
                        throw new Error('Product name must be between 3 and 10 symbols long!');
                    }
                    this._name = name;
                }
            });

            Object.defineProperty(product, 'brand', {
                get: function () {
                    return this._brand;
                },
                set: function (brand) {
                    if (!brand || brand.length < 2 || brand.length > 10) {
                        throw  new Error('Product brand must be between 2 and 10 symbols long!');
                    }
                    this._brand = brand;
                }
            });
            return product;
        }());

        // TODO: modify the total price of a shampoo (+ change the tests)
        var Shampoo = (function (parent) {
            var shampoo = Object.create(parent, {
                init: {
                    value: function (name, brand, price, gender, milliliters, usage) {
                        parent.init.call(this, name, brand, price, gender);
                        this.milliliters = milliliters;
                        this.usage = usage;
                        return this;
                    }
                }
            });
            return shampoo;
        }(Product));

        var Toothpaste = (function (parent) {
            var toothpaste = Object.create(parent, {

                init: {
                    value: function (name, brand, price, gender, ingredients) {
                        parent.init.call(this, name, brand, price, gender);
                        this.ingredients = ingredients;
                        return this;
                    }
                }
            })
            return toothpaste;
        }(Product));

        // TODO: Implement ShopingCard

        var CosmeticFactory = (function () {

                var cosmeticFactory = {
                    createCategory: function (category) {
                        this.categories = Object.create(Category).init(category);
                        return this;
                    },
                    showCategory: function (category) {
                        var result;
                        this.categories.filter(function (ctg) {
                            if (ctg.name === category) {
                                result = ctg.print.call(ctg);
                            }
                        });
                        //DEBUG: console.log(result);
                        return result;
                    },
                    createShampoo: function (name, brand, price, gender, milliliters, usage) {
                        this.shampoos = Object.create(Shampoo).init(name, brand, price, gender, milliliters, usage);
                        return this;
                    },

                    createToothpaste: function (name, brand, price, gender, ingredients) {
                        this.toothpastes = Object.create(Toothpaste).init(name, brand, price, gender, ingredients);
                    },

                    addToCategory: function (categoryName, productName) {
                        var product;
                        if (this.shampoos) {
                            this.shampoos.forEach(function (shampoo) {
                                if (shampoo.name === productName) {
                                    product = shampoo;
                                }
                            });
                        }
                        if (this.toothpastes) {
                            this.toothpastes.forEach(function (toothpaste) {
                                if (toothpaste.name === productName) {
                                    product = toothpaste;
                                }
                            });
                        }
                        if (this.categories) {
                            this.categories.forEach(function (ctg) {
                                if (ctg.name === categoryName) {
                                    ctg.addCosmetics(product);
                                }
                            });
                        }
                    },
                    shoppingCart: function () {
                        // TODO
                    }

                }
                Object.defineProperty(cosmeticFactory, 'shampoos', {
                    get: function () {
                        return this._shampoos;
                    },
                    set: function (newShampoo) {
                        this._shampoos = this._shampoos || [];

                        this._shampoos.forEach(function (shampoo) {
                            if (shampoo.name === newToothpaste.name) {
                                throw new Error('Toothpaste with such name already exist!');
                            }
                        });

                        this._shampoos.push(newShampoo);
                    }
                });

                Object.defineProperty(cosmeticFactory, 'toothpastes', {
                    get: function () {
                        return this._toothpastes;
                    },
                    set: function (newToothpaste) {
                        this._toothpastes = this._toothpastes || [];

                        this._toothpastes.forEach(function (toothpaste) {
                            if (toothpaste.name === newToothpaste.name) {
                                throw new Error('Toothpaste with such name already exist!');
                            }
                        });

                        this._toothpastes.push(newToothpaste);
                    }
                });

                Object.defineProperty(cosmeticFactory, 'categories', {
                    get: function () {
                        return this._categories;
                    },
                    set: function (value) {
                        this._categories = this._categories || [];

                        this._categories.forEach(function (category) {
                            if (category.name === value.name) {
                                throw new Error('Category with such name already exist!')
                            }
                        })

                        this._categories.push(value);
                    }
                });
                return cosmeticFactory;
            }());


        return {
            Category: Category,
            Product: Product,
            Shampoo: Shampoo,
            Toothpaste: Toothpaste,
            CosmeticFactory: CosmeticFactory
        }
    }()
    return cosmeticShop;
}


module.exports = solve;