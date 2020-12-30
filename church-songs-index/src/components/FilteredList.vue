<template>
	<table>
		<tr>
			<th>Code</th>
			<th>歌名</th>
			<th>第一句</th>
			<th>調</th>
			<th>Remark</th>
			<th>歌名字數</th>
		</tr>
		<tr v-for="song in filteredResults" :key="song.code">
			<td class="no-wraps">{{ song.code }}</td>
			<td>{{ song.name }}</td>
			<td>{{ song.firstLine }}</td>
			<td>{{ song.key }}</td>
			<td>{{ song.remark }}</td>
			<td>{{ song.name.length }}</td>
		</tr>
	</table>
</template>

<script>
export default {
	name: 'filtered-list',
	props: {
		filteredSongs: {
		}
	},
	data() {
		return {
		}
	},
	methods: {
	},
	computed: {
		filteredResults() {
			return this.filteredSongs
		}
	}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
table, th, td {
	border: 1px solid black;
	border-collapse: collapse;
}

table {
  width: 95%;
  margin: auto;
}

.no-wraps {
  white-space: nowrap;
  max-width: 100%;
}

</style>
