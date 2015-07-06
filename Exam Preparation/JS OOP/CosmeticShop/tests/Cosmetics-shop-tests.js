// var solve = require('../task/gyonchev')();
var solve = require('../task/Cosmetics-shop')();
var expect = require('chai').expect;
var category = solve.Category;
var Product = solve.Product;
var Shampoo = solve.Shampoo;
var Toothpaste = solve.Toothpaste;
var CosmteticFactory = solve.CosmeticFactory;

describe('Cosmetic shop checks', function () {


    it('expect to create Category and add it to Factory categories [one category] ', function () {
        var factory = Object.create(CosmteticFactory),
            forMale = factory.createCategory('forMale');

        expect(factory.categories.length).to.be.eql(1);
    });

    it('expect to create Category and add it to Factory categories [3 categories] ', function () {
        var factory = Object.create(CosmteticFactory),
            forMale = factory.createCategory('forMale'),
            forWomen = factory.createCategory('forWomen'),
            ecoBioGreen = factory.createCategory('ecoBioGreen');

        expect(factory.categories.length).to.be.eql(3);
    });

    it('expect added category to Factory to be inited [one category] ', function () {
        var factory = Object.create(CosmteticFactory),
            forMale = factory.createCategory('forMale');

        expect(factory.categories[0].name).to.be.eql('forMale');
    });

    it('expect added categories to Factory to be inited [3 categories] ', function () {
        var factory = Object.create(CosmteticFactory),
            forMale = factory.createCategory('forMale'),
            forWomen = factory.createCategory('forWomen'),
            ecoBioGreen = factory.createCategory('ecoBioGreen');

        expect(factory.categories[0].name).to.be.eql('forMale') &&
        expect(factory.categories[1].name).to.be.eql('forWomen') &&
        expect(factory.categories[2].name).to.be.eql('ecoBioGreen');
    });

    it('expect adding categories with equal names to throw', function () {
        var test = function () {
            var factory = Object.create(CosmteticFactory),
                category = factory.createCategory('Repeated'),
                sameCategory = factory.createCategory('Repeated');
        };
        expect(test).to.throw();
    });
    describe('Shampoo checks', function () {
        it('expect Shampoo to be created', function () {
            var lush = Object.create(Shampoo);
            expect(lush).to.exist;
        });

        it('expect Shampoo to be created and to have correct property [name]', function () {
            var lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 8, 'unisex', 250, 'everyday');
            expect(lush.name).to.be.eql('Lush Fig');
        });

        it('expect Shampoo to be created and to have correct property [brand]', function () {
            var lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 8, 'unisex', 250, 'everyday');
            expect(lush.brand).to.be.eql('Lush');
        });

        it('expect Shampoo to be created and to have correct property [price]', function () {
            var lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 8, 'unisex', 250, 'everyday');
            expect(lush.price).to.be.eql(8);
        });

        it('expect Shampoo to be created and to have correct property [gender]', function () {
            var lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 8, 'unisex', 250, 'everyday');
            expect(lush.gender).to.be.eql('unisex');
        });

        it('expect Shampoo to be created and to have correct property [milliliters]', function () {
            var lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 8, 'unisex', 250, 'everyday');
            expect(lush.milliliters).to.be.eql(250);
        });

        it('expect Shampoo to be created and to have correct property [usage]', function () {
            var lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 8, 'unisex', 250, 'everyday');
            expect(lush.usage).to.be.eql('everyday');
        });
    });

    describe('Toothpaste checks', function () {
        it('expect Toothpaste to be created', function () {
            var lush = Object.create(Toothpaste);
            expect(lush).to.exist;
        });

        it('expect Toothpaste to be created and to have correct property [name]', function () {
            var lush = Object.create(Toothpaste).init('Lush Fig', 'Lush', 8, 'unisex', 'lemon');
            expect(lush.name).to.be.eql('Lush Fig');
        });

        it('expect Toothpaste to be created and to have correct property [brand]', function () {
            var lush = Object.create(Toothpaste).init('Lush Fig', 'Lush', 8, 'unisex', 'lemon');
            expect(lush.brand).to.be.eql('Lush');
        });

        it('expect Toothpaste to be created and to have correct property [price]', function () {
            var lush = Object.create(Toothpaste).init('Lush Fig', 'Lush', 8, 'unisex', 'lemon');
            expect(lush.price).to.be.eql(8);
        });

        it('expect Toothpaste to be created and to have correct property [gender]', function () {
            var lush = Object.create(Toothpaste).init('Lush Fig', 'Lush', 8, 'unisex', 'lemon');
            expect(lush.gender).to.be.eql('unisex');
        });

        it('expect Toothpaste to be created and to have correct property [ingredients]', function () {
            var lush = Object.create(Toothpaste).init('Lush Fig', 'Lush', 8, 'unisex', 'lemon');
            expect(lush.ingredients).to.be.eql('lemon');
        });

    });

    describe('Print method of Category checks [1 category in the factory]', function () {
        it('expect Category to print product correctly [1product: shampoo]', function () {
            var factory = Object.create(CosmteticFactory),
                unisex = factory.createCategory('Unisex'),
                lush = Object.create(Shampoo).init('Lush Fig', 'Lush', 9, 'unisex', 250, 'everyday'),
                categoryToCheck = factory.categories[0];
            categoryToCheck.addCosmetics(lush);

            var result = categoryToCheck.print();
            var check = printProduct(categoryToCheck, categoryToCheck.cosmetics);

            expect(result).to.be.eql(check);
        });

        it('expect Category to print product correctly [1product: toothpaste]', function () {
            var factory = Object.create(CosmteticFactory),
                unisex = factory.createCategory('Unisex'),
                lush = Object.create(Toothpaste).init('Lush Fig', 'Lush', 9, 'unisex', 'lemon and carnation'),
                categoryToCheck = factory.categories[0];
            categoryToCheck.addCosmetics(lush);

            var result = categoryToCheck.print();
            var check = printProduct(categoryToCheck, categoryToCheck.cosmetics);

            expect(result).to.be.eql(check);
        });

        it('expect Category to print product correctly [2 products: shampoo & toothpaste]', function () {
            var factory = Object.create(CosmteticFactory),
                unisex = factory.createCategory('Unisex'),
                lushToothpaste = Object.create(Toothpaste).init('Lush Lemon', 'Lush', 25, 'unisex', 'happiness, love and non-violence'),
                lushShampoo = Object.create(Shampoo).init('Lush Shampoo', 'Lush', 9, 'unisex', 250, 'everyday'),
                categoryToCheck = factory.categories[0];
            categoryToCheck.addCosmetics(lushToothpaste);
            categoryToCheck.addCosmetics(lushShampoo);

            var result = categoryToCheck.print();
            var check = printProduct(categoryToCheck, categoryToCheck.cosmetics);
            expect(result).to.be.eql(check);
        });

        it('expect Category to print product correctly [many products, mixed]', function () {
            var factory = Object.create(CosmteticFactory),
                unisex = factory.createCategory('Unisex'),

                lushToothpaste = Object.create(Toothpaste).init('Lush Lemon', 'Lush', 25, 'unisex', 'happiness, love and non-violence'),
                lushFig = Object.create(Shampoo).init('Lush Shampoo Fig', 'Lush', 9, 'unisex', 250, 'everyday'),
                lushApricot = Object.create(Shampoo).init('Lush Shampoo Apricot', 'Lush', 2, 'unisex', 250, 'Monday for some reason'),
                colgateToothpaste = Object.create(Toothpaste).init('Colgate White++', 'Colgate', 25, 'unisex', 'chemicals :( '),
                lushMango = Object.create(Shampoo).init('Lush Shampoo Mango', 'Lush', 18, 'unisex', 250, 'everyday'),

                categoryToCheck = factory.categories[0];
            categoryToCheck.addCosmetics(lushToothpaste);
            categoryToCheck.addCosmetics(lushFig);
            categoryToCheck.addCosmetics(lushApricot);
            categoryToCheck.addCosmetics(colgateToothpaste);
            categoryToCheck.addCosmetics(lushMango);

            var result = categoryToCheck.print();
            var check = printProduct(categoryToCheck, categoryToCheck.cosmetics);
            expect(result).to.be.eql(check);
        });
    });

    describe('Print method of Category checks [more categories in the factory]', function () {
        it('expect Category print method to print product correctly [1 product(shampoo) in each category]', function () {
            var factory = Object.create(CosmteticFactory),
                forMale = factory.createCategory('forMale'),
                forFemale = factory.createCategory('forFemale'),
                lushFig = Object.create(Shampoo).init('Lush Fig', 'Lush', 9, 'for male', 250, 'Saturday'),
                lushApricot = Object.create(Shampoo).init('Lush Apricot', 'Lush', 9, 'for female', 250, 'Sunday because of reasons'),

                firstCategory = factory.categories[0],
                secondCategory = factory.categories[1],
                results = [],
                checks = [];

            firstCategory.addCosmetics(lushFig);
            secondCategory.addCosmetics(lushApricot);

            results.push(firstCategory.print());
            checks.push(printProduct(firstCategory, firstCategory.cosmetics));

            results.push(secondCategory.print());
            checks.push(printProduct(secondCategory, secondCategory.cosmetics));

            expect(results[0]).to.be.eql(checks[0]) &&
            expect(results[1]).to.be.eql(checks[1]);
        });

        it('expect Category print method to print product correctly [2 products(shampoo & toothpaste) in each category]', function () {
            var factory = Object.create(CosmteticFactory),
                forMale = factory.createCategory('forMale'),
                forFemale = factory.createCategory('forFemale'),

                lushFig = Object.create(Shampoo).init('Lush Fig', 'Lush', 5, 'for male', 250, 'everyday'),
                lushMango = Object.create(Toothpaste).init('Lush Mango', 'Lush', 16, 'for male', 'some ingredients'),
                lushApricot = Object.create(Shampoo).init('Lush Apricot', 'Lush', 25, 'for female', 250, 'Sunday because of reasons'),
                lushApple = Object.create(Toothpaste).init('Lush Apple', 'Lush', 54, 'for female', 'ala bala!!'),

                maleCategory = factory.categories[0],
                femaleCategory = factory.categories[1],
                results = [],
                checks = [];

            maleCategory.addCosmetics(lushFig);
            maleCategory.addCosmetics(lushMango);
            femaleCategory.addCosmetics(lushApricot);
            femaleCategory.addCosmetics(lushApple);


            results.push(maleCategory.print());
            checks.push(printProduct(maleCategory, maleCategory.cosmetics));

            results.push(femaleCategory.print());
            checks.push(printProduct(femaleCategory, femaleCategory.cosmetics));
            expect(results[0]).to.be.eql(checks[0]) &&
            expect(results[1]).to.be.eql(checks[1]);
        });

        it('expect Category print method to print product correctly [many products in each category]', function () {
            var factory = Object.create(CosmteticFactory),
                forMale = factory.createCategory('forMale'),
                forFemale = factory.createCategory('forFemale'),

                lushFig = Object.create(Shampoo).init('Lush Fig', 'Lush', 5, 'for male', 250, 'everyday'),
                lushMango = Object.create(Shampoo).init('Lush Mango', 'Lush', 16, 'for male', 250, 'Saturday'),
                bilkaGrapefruit = Object.create(Toothpaste).init('Bilka Grapefruit', 'Bilka', 5, 'for male', 'grapefruit, non-fluor'),
                someToothpaste = Object.create(Toothpaste).init('some toothpaste', 'Bilka', 16, 'for male', 'magic'),

                lushApricot = Object.create(Shampoo).init('Lush Apricot', 'Lush', 25, 'for female', 250, 'Sunday because of reasons'),
                lushApple = Object.create(Shampoo).init('Lush Apple', 'Lush', 54, 'for female', 250, 'Wednesday!!'),
                bilkaLemon = Object.create(Toothpaste).init('Bilka Lemon', 'Bilka', 25, 'for female', 'lemon, non-fluor'),
                anothertoothpaste = Object.create(Toothpaste).init('aother toothpaste', 'Bilka', 54, 'for female', 'many ingredients, but not fluor'),


                maleCategory = factory.categories[0],
                femaleCategory = factory.categories[1],
                results = [],
                checks = [];

            maleCategory.addCosmetics(lushFig);
            maleCategory.addCosmetics(lushMango);
            maleCategory.addCosmetics(bilkaGrapefruit);
            maleCategory.addCosmetics(someToothpaste);

            femaleCategory.addCosmetics(lushApricot);
            femaleCategory.addCosmetics(lushApple);
            femaleCategory.addCosmetics(bilkaLemon);
            femaleCategory.addCosmetics(anothertoothpaste);


            results.push(maleCategory.print());
            checks.push(printProduct(maleCategory, maleCategory.cosmetics));

            results.push(femaleCategory.print());
            checks.push(printProduct(femaleCategory, femaleCategory.cosmetics));
            //DEBUG console.log(results[0]);
            expect(results[0]).to.be.eql(checks[0]) &&
            expect(results[1]).to.be.eql(checks[1]);

        });

        it('expect Category print method to print product correctly [no producs added]', function () {
            var factory = Object.create(CosmteticFactory),
                unisex = factory.createCategory('Unisex'),
                categoryToCheck = factory.categories[0],

                result = categoryToCheck.print(),
                check = printProduct(categoryToCheck, categoryToCheck.cosmetics);
            expect(result).to.be.eql(check);
        });
    });

    describe('createToothpaste checks', function () {
        it('expect createToothpaste to add toothpaste to factory', function () {
            var factory = Object.create(CosmteticFactory);
            factory.createToothpaste('Lush Fig', 'Lush', 9, 'unisex', 'lemon and carnation')

            expect(factory.toothpastes[0].name).to.be.eql('Lush Fig');
        });

        it('expect createToothpaste to throw if toothpaste with such name already exist', function () {
            var test = function () {
                var factory = Object.create(CosmteticFactory);
                factory.createToothpaste('Lush Fig', 'Lush', 9, 'unisex', 'lemon and carnation');
                factory.createToothpaste('Lush Fig', 'Lush54', 15, 'unisex', 'lemon');
            }
            expect(test).to.throw();
        });
    });

    describe('createShampoo checks', function () {
        it('expect createShampoo to add shampoo to factory', function () {
            var factory = Object.create(CosmteticFactory);
            factory.createShampoo('Lush Fig', 'Lush', 9, 'unisex', 450, 'sure you know when and how to use it');

            expect(factory.shampoos[0].name).to.be.eql('Lush Fig');
        });

        it('expect createShampoo to throw if shampoo with such name already exist', function () {
            var test = function () {
                var factory = Object.create(CosmteticFactory);
                factory.createShampoo('Lush Fig', 'Lush', 9, 'unisex', 380, 'everyday');
                factory.createShampoo('Lush Fig', 'Lush54', 15, 'unisex', 420, 'really didnt get the need for this one..');
            }
            expect(test).to.throw();
        });
    });

    describe('showCategory checks', function () {
        it('expect showCategory to return correct list of products, added to this category [1 product]', function () {
            var factory = Object.create(CosmteticFactory),
                result,
                check,
                category,
                shampoo;

            category = factory.createCategory('Natural');
            category = factory.categories[0];
            shampoo = factory.createShampoo('Lush Shampoo', 'Lush', 54, 'female', 380, 'everyday')
            category.addCosmetics(shampoo);
            factory.addToCategory('Natural', 'Lush Shampoo');

            result = factory.showCategory('Natural');
            check = printProduct(category, category.cosmetics);
            expect(result).to.be.eql(check);
        });
    });

    describe('Validation checks', function () {
        it('expect Category with no name to throw ', function () {
            var test = function () {
                var factory = Object.create(CosmteticFactory),
                    forMale = factory.createCategory('');
            }
            expect(test).to.throw();
        });

        it('expect Category with name shorter than than 2 chars to throw ', function () {
            var test = function () {
                var factory = Object.create(CosmteticFactory),
                    forMale = factory.createCategory('a');
            }
            expect(test).to.throw();
        });

        it('expect Category with  name longer than 15 chars to throw ', function () {
            var test = function () {
                var factory = Object.create(CosmteticFactory),
                    forMale = factory.createCategory('1234567890123456');
            }
            expect(test).to.throw();
        });

        it('expect Shampoo with no name to throw ', function () {
            var test = function () {
                var shampoo = Object.create(Shampoo).init('')
            }
            expect(test).to.throw();
        });

        it('expect Shampoo with name shorter than than 3 chars to throw ', function () {
            var test = function () {
                var shampoo = Object.create(Shampoo).init('ab');
            }
            expect(test).to.throw();
        });

        it('expect Shampoo with  name longer than 10 chars to throw ', function () {
            var test = function () {
                var shampoo = Object.create(Shampoo).init('123456789012345678901')
            }
            expect(test).to.throw();
        });

        it('expect Toothpaste with no name to throw ', function () {
            var test = function () {
                var toothpaste = Object.create(Toothpaste).init('')
            }
            expect(test).to.throw();
        });

        it('expect Toothpaste with name shorter than than 3 chars to throw ', function () {
            var test = function () {
                var toothpaste = Object.create(Toothpaste).init('ab');
            }
            expect(test).to.throw();
        });

        it('expect Toothpaste with  name longer than 10 chars to throw ', function () {
            var test = function () {
                var toothpaste = Object.create(Toothpaste).init('123456789012345678901')
            }
            expect(test).to.throw();
        });

        it('expect Product\'s brand name with no name to throw ', function () {
            var test = function () {
                var shampoo = Object.create(Shampoo).init('validname', '');
            }
            expect(test).to.throw();
        });

        it('expect Product\s brand name shorter than than 2 chars to throw ', function () {
            var test = function () {
                var product = Object.create(Toothpaste).init('validname', 'a');
            }
            expect(test).to.throw();
        });

        it('expect Product\s  name longer than 10 chars to throw ', function () {
            var test = function () {
                var shampoo = Object.create(Shampoo).init('validname', '123456789012345678901')
            }
            expect(test).to.throw();
        });
    });


});


function printProduct(product, cosmetics) {
    if (!cosmetics) {
        return product.name + ' category - ' + 0 + ' products it total';
    }

    var result = product.name + ' category - ' + cosmetics.length + ' products it total';

    cosmetics.forEach(function (product) {
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


