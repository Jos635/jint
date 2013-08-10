/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-354-1.js
 * @description Object.defineProperty will update [[Value]] attribute of named property 'P' successfully when [[Configurable]] attribute is true and [[Writable]] attribute is false, 'O' is an Object object (8.12.9 step - Note)
 */


function testcase() {

        var obj = {};

        Object.defineProperty(obj, "property", {
            value: 1001,
            writable: false,
            configurable: true
        });

        Object.defineProperty(obj, "property", {
            value: 1002
        });

        return dataPropertyAttributesAreCorrect(obj, "property", 1002, false, false, true);
    }
runTestCase(testcase);