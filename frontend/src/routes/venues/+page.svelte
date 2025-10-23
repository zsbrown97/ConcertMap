<script lang="ts">
    export let data;

    const {venues} = data;
    let latlng: number[][] = []

    venues.forEach((v) => {
        latlng.push([v.latitude, v.longitude])
    })
</script>

{#each latlng as x}
<h1>
    {x[0]} - {x[1]}
</h1>
{/each}



<style lang="postcss">
    @reference "tailwindcss";

    :global(html) {
        background-color: theme(--color-gray-100);
    }
</style>