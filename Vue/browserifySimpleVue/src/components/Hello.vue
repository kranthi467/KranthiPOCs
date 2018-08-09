<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h1>{{nameForView}}</h1>
    <h2>{{computedValue}}</h2>
    <slot></slot>
  </div>
</template>

<script>
export default {
  props: {
      nameForView:{
          default: '  '
      }
      },
  name: 'hello',
  data () {
    return {
      msg: 'Component: Hi, Welcome to Your Vue.js App'
    }
  },
//   methods: {
//       Update: () => {
//           console.log(name)
//           name = "Hello"
//           return name;
//       }
//   },
  computed: {
        computedValue: function () {
            if ( this.nameForView != null ) {
                name = this.nameForView;
                return name
            }

            return '';
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
