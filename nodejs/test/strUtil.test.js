const target = require(global.JS_PATH + '/util/strUtil');

test('adds 1 + 2 to equal 3', () => {
  expect(target.sum(1, 2)).toBe(3);
});
