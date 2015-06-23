/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 *
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 *
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 *
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 *
 * property children
 * each child is a domElement or a string
 *
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * // method removeAttribute(attribute)
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {
        var domElement = {
            init: function (type) {
                this.type = type;
                return this;
            },
            appendChild: function (child) {
                this.children = child;
                return this;
            },
            addAttribute: function (name, value) {
                this.attributes = {name: name, value: value};
                return this;
            },
            get innerHTML() {
                var openTag = '<',
                    closeTag = '>';
                var result = openTag + this.type;

                if (this.attributes) {
                    var currAttr = this.attributes;
                    result += getAttributesPair(currAttr);
                }
                result += closeTag;

                if (this.children) {
                    for (var child in this.children) {
                        if (typeof  this.children[child] == 'string') {
                            result += this.children[child];
                            // result += this._children[child]._content || '';
                        }
                        else {
                            result += this.children[child].innerHTML;
                        }
                    }
                }
                result += this.content || '';
                result += openTag + '/' + this.type + closeTag;
                return result;
            }
        };

        Object.defineProperty(domElement, 'parent', {
            get: function () {
                return this._parent;
            },
            set: function (parent) {
                this._parent = parent;
            }
        });

        Object.defineProperty(domElement, 'attributes', {
            get: function () {
                return this._attributes;

            },
            set: function (attribute) {
                var name = attribute.name;
                var value = attribute.value;
                if (name === '' || !(/^[A-Za-z0-9-]{1,}$/i).test(name)) {
                    throw new Error('Valid attribute name must contain only Latin letters, digits or dashes and must not be an empty string!');
                }
                this._attributes = this._attributes || [];
                this._attributes[name] = value;
            }
        });

        Object.defineProperty(domElement, 'content', {
            get: function () {
                return this._content || '';
            },
            set: function (content) {
                if (this.children) {
                    content = '';
                }
                if (!typeof content === 'string') {
                    throw new Error('Type of content must be string!');
                }
                this._content = content;
            }
        });

        Object.defineProperty(domElement, 'children', {
            get: function () {
                return this._children;
            },
            set: function (child) {
                if (typeof child !== 'string' && typeof  (child._type) === 'undefined') {
                 throw new Error(' ');
                 }
                if (typeof (child._type) !== 'undefined') {
                    child.parent = this.type;
                }

                this.content = '';
                this._children = this.children || [];
                this._children.push(child);
            }
        });

        Object.defineProperty(domElement, 'type', {
            get: function () {
                return this._type;
            },
            set: function (value) {
                if (typeof value !== 'string') {
                    throw new Error('A valid type must be string!');
                }
                if (!/[A-Za-z0-9]{1,}$/i.test(value)) {
                    throw  new Error('A valid type must contain only Latin letters and digits!');
                }

                this._type = value;
            }
        });

        function getAttributesPair(currAttributes) {
            var result = '',
                key,
                keys = [],
                elemAttributes = currAttributes;

            for (var key in currAttributes) {
                keys.push(key);
            }

            keys = keys.sort(function (a, b) {
                return b < a;
            });
            for (key in keys) {
                result += ' ' + keys[key] + '="' + elemAttributes[keys[key]] + '"';
            }
            return result;
        }

        return domElement;
    }());
    return domElement;
}

module.exports = solve;
