<template>
	<div class="menu">
		<div class="menu-item">
			<a href='index.html'>Home</a>
		</div>
		<div class="menu-item">
			<a href='about.html'>About</a>
		</div>
	</div>
</template>

<script>
export default {
  name: 'menu-bar'
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.menu {
	display: flex;
	align-items: center;
	justify-content: space-around;
}

.menu-item {
	flex: 1;
	border: 5px solid red;
	text-align: center;
	font-size: 36px;
	background-color: #e3dfde; /* Yellow */
}
</style>
