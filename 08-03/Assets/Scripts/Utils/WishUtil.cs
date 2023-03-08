namespace Scripts.Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class WishUtil : IEnumerable<string>
    {
        private List<string> Contents { get; }

        public WishUtil()
        {
            this.Contents = new List<string>();
        }

        /// <summary>
        /// Add a content to the list. You can use <name> to replace the name of the player
        /// </summary>
        /// <param name="content"></param>
        public void Add(string content)
        {
            this.Contents.Add(content);
        }

        /// <summary>
        /// Load all content from Resources/Contents folder
        /// </summary>
        public void LoadContentFromResources()
        {
            var contents = Resources.LoadAll<TextAsset>("Contents");
            foreach (var content in contents)
            {
                this.Contents.Add(content.text);
            }
        }

        /// <summary>
        /// Use this method to get a random content with a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string RandomContent(string name)
        {
            var index = Random.Range(0, this.Contents.Count);
            return this.Contents[index].Replace("<name>", name);
        }

        /// <summary>
        /// After you get the content, you can use this method to set the content to UI with animation
        /// </summary>
        /// <param name="content"></param>
        /// <param name="setter"></param>
        /// <param name="delay"></param>
        public async Task SetContentWithAnimation(string content, Action<char> setter, int delay = 100)
        {
            foreach (var c in content)
            {
                setter.Invoke(c);
                await Task.Delay(delay);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this.Contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}