using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Trade
    {

        public Trade(string name, double TradeShare, bool isExploded, string colour)
        {
            _name = name;
            _TradeShare = TradeShare;
            _isExploded = isExploded;
            _colour = colour;

        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private double _TradeShare;
        public double TradeShare
        {
            get { return _TradeShare; }
            set { _TradeShare = value; }
        }
        private bool _isExploded;
        public bool IsExploded
        {
            get { return _isExploded; }
            set { _isExploded = value; }
        }
        private string _colour;
        public string COLOUR
        {
            get { return _colour; }
            set { _colour = value; }

        }


    }
