<template>
  <div id="app">
	<menu-bar v-if="false"></menu-bar>
	<div class="worship">
	
		<div class="worship-info">
			<h1>迦琳基督教會祟拜詩歌</h1>
		</div>
		
		<div class="worship-image">
			<img src="./assets/images/Cross.jpg" />
		</div>
		
		<div class="grid-container">
			<filter-form @search-terms-entered="search"></filter-form>
			<div class="updated-info">
				<h2>Website last updated: 28/11/2020</h2>
				<h2>Spreadsheet last updated: 28/11/2020</h2>
			</div>
		</div>
		
		<filtered-list :filtered-songs="filteredSongs"></filtered-list>
		
		<br />
		
		<div class="back-to-top">
			<button type="button" @click="scrollToTop">Back to top</button>
		</div>
		
	</div>
  </div>
</template>

<script>
import MenuBar from './components/MenuBar.vue'
import FilterForm from './components/FilterForm.vue'
import FilteredList from './components/FilteredList.vue'
import songs from '@/data/songs'


export default {
	name: 'App',
	components: {
		MenuBar,
		FilterForm,
		FilteredList
	},
	mounted:function(){
		let searchTerms = {
			stroke: null,
			nameLength: null,
			searchCode: null,
			wordContains: null,
		}
		
		this.search(searchTerms) //search will execute at pageload
	},
	data() {
		return {
			image: './Cross.jpg',
			filteredSongs: [],
			songs
		}
	},
	methods: {
		search(searchTerms) {
			this.filteredSongs = []
			for (var i = 0; i < this.songs.length; i++) {
				if (searchTerms.searchCode && searchTerms.searchCode != this.songs[i].code) {
					// searchCode not matched
					continue
				}
				
				if (searchTerms.stroke && searchTerms.stroke != this.songs[i].stroke) {
					// stroke not matched
					continue
				}
				
				if (searchTerms.nameLength && searchTerms.nameLength != this.songs[i].name.length) {
					// name length not matched
					continue
				}
				
				if (searchTerms.wordContains) {
					var searchWord = searchTerms.wordContains.toLowerCase()
					if (!this.songs[i].name.toLowerCase().includes(searchWord) && !this.songs[i].firstLine.toLowerCase().includes(searchWord) && !this.songs[i].remark.toLowerCase().includes(searchWord)) {
						// wordContains not matched
						continue
					}
				}
				
				if (searchTerms.key && searchTerms.key != this.songs[i].key) {
					// key not matched
					continue
				}
				
				this.filteredSongs.push(this.songs[i])
			}
		},
		scrollToTop() {
			window.scrollTo(0,0);
		},
	},
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.updated-info {
  text-align: right;
}
</style>
