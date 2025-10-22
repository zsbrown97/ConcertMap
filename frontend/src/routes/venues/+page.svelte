<script lang="ts">
    export let data;

    const {venues} = data;
</script>

{#each venues as v}
<h1>
    {v.name}
</h1>
{/each}


<style lang="postcss">
    @reference "tailwindcss";

    :global(html) {
        background-color: theme(--color-gray-100);
    }
</style>