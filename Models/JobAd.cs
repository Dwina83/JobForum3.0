namespace JobForum3._0.Models
{
    public class JobAd
    {



        public Total total { get; set; }
        public Hit[] hits { get; set; }
    }

    public class Total
    {
        public int value { get; set; }
    }

    public class Hit
    {
        public string id { get; set; }
        public string headline { get; set; }
        public string brief { get; set; }
        public Occupation_Group occupation_group { get; set; }
        public Occupation_Field occupation_field { get; set; }
        public Employer employer { get; set; }
        public Workplace_Addresses[] workplace_addresses { get; set; }
        public DateTime publication_date { get; set; }
        public Source_Links[] source_links { get; set; }
    }

    public class Occupation_Group
    {
        public string label { get; set; }
        public string concept_id { get; set; }
    }

    public class Occupation_Field
    {
        public string label { get; set; }
        public string concept_id { get; set; }
    }

    public class Employer
    {
        public string name { get; set; }
    }

    public class Workplace_Addresses
    {
        public string municipality_concept_id { get; set; }
        public string municipality { get; set; }
        public string region_concept_id { get; set; }
        public string region { get; set; }
        public string country_concept_id { get; set; }
        public string country { get; set; }
    }

    public class Source_Links
    {
        public string label { get; set; }
        public string url { get; set; }
    }
}
    