using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace ReditXamarinApp.Models
{
    public class Post
    {
        public string Kind { get; set; }
        public PostData Data { get; set; }
    }

    public class PostData
    {
        public string After { get; set; }
        public IList<PostItem> Children { get; set; }
        public object Before { get; set; }
    }

    public class PostItem
    {
        public string Kind { get; set; }
        public PostItemDetail Data { get; set; }
    }

    public class PostItemDetail
    {
        public bool Archived { get; set; }
        public bool Clicked { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public double Created { get; set; }
        public string Title { get; set; }
        public double Created_utc { get; set; }
        public int Num_comments { get; set; }
        public Preview Preview { get; set; }
    }

    public class Preview
    {
        public IList<Image> Images { get; set; }
    }

    public class Image
    {
        public Source Source { get; set; }
    }

    public class Source
    {
        public string Url { get; set; }
    }

}
